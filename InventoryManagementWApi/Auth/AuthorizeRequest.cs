using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventoryManagementWApi.Auth
{
    [AttributeUsage(AttributeTargets.All)]
    public class AuthorizeRequest : Attribute, IAuthorizationFilter
    {
        public string? UserRoles { get; set; }
        
        public AuthorizeRequest()
        {

        }
        public AuthorizeRequest(params string[] roles) : base()
        {
            UserRoles = string.Join(",", roles);
        }

        /// <summary>
        /// This method is invoked when any action having AuthAttribute, This method is responsible for following
        /// 1. Get the security token from header
        /// 2. Validate the token, exmaple code assumes that there is another auth server (api) responsible for this 
        ///     so it try to send the token to a configurable endpoint to get it validated,  In your case it may be the API, some local component etc
        /// 3. This method also assumes that auth server base url as well as validate token action url are present somewhere and 
        ///     there are local methods to get these URLs, you may hardcode these URLs in these methods or may get from CONFIG file
        /// 4. This method passes token and list of roles to the token validation URL so and expects that this endpoint ensure that 
        ///     - token is valid
        ///     - user is in the role(s)
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            //TODO: for now this method will return and will not do any thing. Please use given code below as example and adjust/modify as per your requirements
            if (UserRoles.Contains(DemandedRoles.NoSecurity))
            {
                Trace.WriteLine($"{filterContext.ActionDescriptor.DisplayName} requested validation for roles {UserRoles}, system will return without any security");
                return;
            }

            var securityToken = ExtractToken(filterContext);
            
            if (string.IsNullOrEmpty(securityToken)) 
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            bool tokenValidated = TokenValid(securityToken, GetValidationServerBaseUri());
            if(!tokenValidated)
                filterContext.Result = new UnauthorizedResult();

        }

        private string ExtractToken(AuthorizationFilterContext filterContext)
        {
            string securityToken = Convert.ToString(filterContext.HttpContext.Request.Headers["Authorization"]);
            if (!string.IsNullOrEmpty(securityToken))
                return securityToken.Replace("Bearer ", "");
            else
                return securityToken;
        }

        private bool TokenValid(string securityToken, string tokenValidationServerBaseUrl)
        {
            bool tokenValid = false;
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(tokenValidationServerBaseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", securityToken);
                using var validationResponse = httpClient.GetAsync(GetTokenValidationEndPointUrlFormat(securityToken, string.Empty)).Result;
                {
                    if (validationResponse.StatusCode == HttpStatusCode.OK)
                    {
                        bool.TryParse(validationResponse.Content.ReadAsStringAsync().Result, out tokenValid);
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: please use your logging mechanism 
                Trace.WriteLine(ex.ToString());
            }

            return tokenValid;
        }

        private string GetValidationServerBaseUri()
        {
            return "https://authserver:8023/";
        }

        private string GetTokenValidationEndPointUrlFormat(string token, string roleList)
        {
            return $"api/Auth/ValidateToken?securityToken={token}&&role={roleList}";
        }
    }
}

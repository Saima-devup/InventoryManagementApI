using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;

namespace InventoryManagementWApi.HealthChecks
{
    /// <summary>
    /// This class implements the health check interface, As part of the this check you may try to check the API settings/configurations
    /// and make sure that all settings exists and that they are all valid, if any setting doesn't exists or isn't valid API may report unhealthy status
    /// </summary>
    public class SystemConfigHealthCheck : IHealthCheck
    {
        //TODO
        // public IInternalConfigStore _configStore { get; set; }
        // public SystemConfigHealthCheck(IInternalConfigStore IInternalConfigStore _configStore)
        // {
        //    _configStore = configStore;
        // }

        public SystemConfigHealthCheck()
        
        {
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                Trace.WriteLine("performing SystemConfigHealthCheck...");
                // TODO: please perform any system configuration related checks here, for example
                // if you system need to upload files to a folder or read data from some document or print a repport at some printer
                // please check all of such resources here to ensure that they are all configured and this service can access those resources 
                // _configStore.GetSystemConfigurations().ForEach(x=> x.Validate())

                return HealthCheckResult.Healthy($"All system level configurations are valid");
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }
    }
}

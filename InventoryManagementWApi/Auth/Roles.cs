namespace InventoryManagementWApi.Auth
{
    public static class DemandedRoles
    {
        /// <summary>
        /// TODO: This NoSecurity is a dummy role to provide the concept only, This means that no authentication or authorization will be applied
        /// Please adjust this as per your requirements, remove this unsecure option and hook up this JWT based security infratsructure to work as per your need
        /// </summary>
        public const string NoSecurity = "NoSecurity";
        public const string Admin = "Admin";
        public const string SuperAdmin = "SuperAdmin";
        public const string User = "User";
        public const string SuperUser = "SuperUser";
    }
}

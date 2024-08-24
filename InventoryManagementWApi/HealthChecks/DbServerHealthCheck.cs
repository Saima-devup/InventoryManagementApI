using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;

namespace InventoryManagementWApi.HealthChecks
{
    /// <summary>
    /// This class implements the health check interface, As part of the this check it try to connect to the DB and 
    /// if connection is successfull it return a healthy status. You may go ahead and add more DB tests that you think 
    /// are necessary for this API
    /// </summary>
    public class DbServerHealthCheck : IHealthCheck
    {
        private readonly string _connectionString;

        public DbServerHealthCheck(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                Trace.WriteLine("performing DbServerHealthCheck...");
                using (var connection = new SqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (SqlException)
                    {
                        return HealthCheckResult.Unhealthy($"Unable to connect to DB at {_connectionString}");
                    }
                }

                // TODO you may do a detailed check here by verifying that DB objects exists etc.
                // TODO you may also invoke service class from here to perform these checks instead of connecting to DB here

                return HealthCheckResult.Healthy($"DB connection successfull to {_connectionString}");
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecks.HealthChecks;

public class DatabaseConnectionCheck : IHealthCheck
{
  public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
      CancellationToken cancellationToken = default)
  {

    try
    {
      using var connection = new SqlConnection("Data Source=.;Initial Catalog=WMSDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


      await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

      using var command = connection.CreateCommand();
      command.CommandText = "Select 1";
      object result = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);

      return HealthCheckResult.Healthy("The status of the connection is open");

    }
    catch (Exception ex)
    {
      return HealthCheckResult.Unhealthy("The status of the connection is close");
    }

  }

}


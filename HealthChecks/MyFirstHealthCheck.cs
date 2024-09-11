using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecks.HealthChecks;

public class MyFirstHealthCheck : IHealthCheck
{
  public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
     CancellationToken cancellationToken = default)
  {
    return Task.FromResult(HealthCheckResult.Healthy("This could be a service"));
  }
}

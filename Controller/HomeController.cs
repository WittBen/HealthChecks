using Microsoft.AspNetCore.Mvc;

namespace HealthChecks.Controller
{
  public class HomeController : ControllerBase
  {


    [HttpPost("DefaultNotify")]
    public async Task DefaultNotify(object defaultNotification)
    {
    //  _logger.LogInformation("Received default notification with message: {Message}", defaultNotification.Message);

      /* Other logic follows ... */
    }
  }
}

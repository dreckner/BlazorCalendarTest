using Csla;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCalendarTest.Blazor.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DataPortalController(ApplicationContext applicationContext) : Csla.Server.Hosts.HttpPortalController(applicationContext)
  {
    [HttpGet]
    public string Get()
    {
        return "DataPortal is running...";
    }
  }
}
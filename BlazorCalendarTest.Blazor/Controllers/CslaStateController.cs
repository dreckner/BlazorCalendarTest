using Microsoft.AspNetCore.Mvc;
using Csla;
using Csla.State;

namespace BlazorCalendarTest.Blazor.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CslaStateController(ApplicationContext applicationContext, ISessionManager sessionManager) : Csla.AspNetCore.Blazor.State.StateController(applicationContext, sessionManager)
  { }
  
}
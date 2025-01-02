using Microsoft.AspNetCore.Mvc;

namespace BartTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : ControllerBase
    {
        [HttpGet]
        public string Get(string userName)
        {
            return userName;
        }


    }
}

using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController: ControllerBase
    {
        //backlog 1 done 

        // GET api/welcome
        [HttpGet]
        public string GetWelcomeMessage()
        {
            return "Welcome to Web API!";
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        //Get api / products 
        [HttpGet]

        public IEnumerable<string> GetProducts()

        {
            return new List<string> { "Laptop", "SmartPhone", "Tablate" };
        }
        }

       
    
}

using Microsoft.AspNetCore.Mvc;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    public class MakeController
    {
        [HttpGet("[action]")]
        public ActionResult Index(){
            return new OkObjectResult("this is a test");
        }
    }
}
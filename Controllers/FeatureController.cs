using Microsoft.AspNetCore.Mvc;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    public class FeatureController
    {
        [HttpGet("[action]")]
        public IActionResult Index() {
            return new OkObjectResult("this in the index action of the feature controller. Eventuallyit will return a list of feature stored in a database");
        }
    }
}
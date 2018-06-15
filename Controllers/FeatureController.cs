using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vega.Models;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    public class FeatureController
    {
        private readonly VegaContext _context;

        public FeatureController(VegaContext context) {
            _context = context;
        }

        [HttpGet("[action]")]
        public IActionResult Index() {
            _context.Features.ToList();
            
            return new OkObjectResult(_context.Features.ToList());
        }
    }
}
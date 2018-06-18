using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vega.Models;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    public class FeaturesController
    {
        private readonly VegaContext _context;

        public FeaturesController(VegaContext context) {
            _context = context;
        }

        [HttpGet("/api/features")]
        public IActionResult Index() {
            _context.Features.ToList();
            
            return new OkObjectResult(_context.Features.ToList());
        }
    }
}
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    public class FeaturesController
    {

        private readonly VegaDbContext _context;

        public FeaturesController(VegaDbContext context) {
            _context = context;
        }

        [HttpGet("/api/features")]
        public IActionResult Index() {
            _context.Features.ToList();
            
            return new OkObjectResult(_context.Features.ToList());
        }
    }
}
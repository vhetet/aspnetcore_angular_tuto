using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    public class MakesController
    {
        private VegaDbContext context { get; }
        private IMapper mapper { get; }

    
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/makes")]
        public ActionResult Index(){
            var makes = context.Makes.Include(m => m.CarModels).ToList();
            var mapMakes = Mapper.Map<List<Make>, List<MakeResource>>(makes);
            var okObjectResult = new OkObjectResult(mapMakes);
            return okObjectResult;
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using vega.Models;

namespace vega.Controllers.Resources
{
    public class MakeResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CarModelResource> CarModels { get; set; }

        public MakeResource()
        {
            CarModels = new Collection<CarModelResource>();
        }
    }
}
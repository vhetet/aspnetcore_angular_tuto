using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vega.Models;

namespace Vega.Controllers.Resources
{
    public class MakeResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> CarModels { get; set; }

        public MakeResource()
        {
            CarModels = new Collection<KeyValuePairResource>();
        }
    }
}
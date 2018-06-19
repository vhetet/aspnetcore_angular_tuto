using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public ICollection<CarModel> CarModels { get; set; }

        public Make()
        {
            CarModels = new Collection<CarModel>();
        }
    }
}
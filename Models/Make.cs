namespace vega.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
    }
}
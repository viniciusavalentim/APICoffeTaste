using APICoffeeTaste.Service.HotDrinksService;
using System.Text.Json.Serialization;

namespace APICoffeeTaste.Models
{
    public class IngredientsIcedDrinksModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Quantity { get; set; }
        public string? Unit { get; set; }
        public int IcedDrinksId { get; set; }
        [JsonIgnore]
        public IcedDrinksModel? IcedDrinks { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace APICoffeeTaste.Models
{
    public class IngredientsHotDrinksModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Quantity { get; set; }
        public string? Unit { get; set; }
        public int HotDrinksId { get; set; }
        [JsonIgnore]
        public HotDrinksModel? HotDrinks { get; set; }
    }
}

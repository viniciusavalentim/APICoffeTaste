using System.Text.Json.Serialization;

namespace APICoffeeTaste.Models
{
    public class IngredientsSoftDrinksModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Quantity { get; set; }
        public string? Unit { get; set; }
        public int SoftDrinksId { get; set; }
        [JsonIgnore]
        public SoftDrinksModel? SoftDrinks { get; set; }
    }
}

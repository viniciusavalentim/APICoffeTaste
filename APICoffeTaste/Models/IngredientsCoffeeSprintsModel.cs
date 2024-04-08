using System.Text.Json.Serialization;

namespace APICoffeeTaste.Models
{
    public class IngredientsCoffeeSprintsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Quantity { get; set; }
        public string? Unit { get; set; }
        public int CoffeeSprintsId { get; set; }
        [JsonIgnore]
        public CoffeeSprintsModel? CoffeeSprints { get; set; }
    }
}

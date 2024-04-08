using System.Text.Json.Serialization;

namespace APICoffeeTaste.Models
{
    public class IngredientsTeasModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Quantity { get; set; }
        public string? Unit { get; set; }
        public int TeasId { get; set; }
        [JsonIgnore]
        public TeasModel? Teas { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace APICoffeeTaste.Models
{
    public class IngredientsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Quantidade { get; set; }
        public string? Unidade { get; set; }
        public int BebidasGeladasId { get; set; }
        [JsonIgnore]
        public IcedDrinksModel? BebidasGeladas { get; set; }
    }
}

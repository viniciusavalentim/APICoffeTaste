using System.Text.Json.Serialization;

namespace APICoffeeTaste.Models
{
    public class IngredientesModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public double Quantidade { get; set; }
        public string? Unidade { get; set; }
        public int BebidasGeladasId { get; set; }
        [JsonIgnore]
        public BebidasGeladasModel? BebidasGeladas { get; set; }
    }
}

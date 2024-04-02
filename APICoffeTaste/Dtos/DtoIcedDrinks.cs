using APICoffeeTaste.Models;

namespace APICoffeeTaste.Dtos
{
    public class DtoIcedDrinks
    {
        public string? Name { get; set; }
        public string? Observacoes { get; set; }
        public List<IngredientsModel>? Ingredientes { get; set; }
    }
}

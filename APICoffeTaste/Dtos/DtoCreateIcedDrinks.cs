using APICoffeeTaste.Models;

namespace APICoffeeTaste.Dtos
{
    public class DtoCreateIcedDrinks
    {
        public string? Name { get; set; }
        public string? Observacoes { get; set; }
        public List<DtoCreateIngredients>? Ingredientes { get; set; }
    }
}

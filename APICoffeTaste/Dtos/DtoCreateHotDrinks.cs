using APICoffeeTaste.Models;

namespace APICoffeeTaste.Dtos
{
    public class DtoCreateHotDrinks
    {
        public string? Name { get; set; }
        public string? Observacoes { get; set; }
        public List<IngredientsIcedDrinksModel>? Ingredientes { get; set; }
    }
}

namespace APICoffeeTaste.Models
{
    public class CoffeeSprintsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Observacoes { get; set; }
        public List<IngredientsCoffeeSprintsModel>? Ingredientes { get; set; }
    }
}

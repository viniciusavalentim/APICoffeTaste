namespace APICoffeeTaste.Models
{
    public class SoftDrinksModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Observacoes { get; set; }
        public List<IngredientsSoftDrinksModel>? Ingredientes { get; set; }
    }
}

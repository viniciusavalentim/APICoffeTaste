namespace APICoffeeTaste.Models
{
    public class TeasModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Observacoes { get; set; }
        public List<IngredientsTeasModel>? Ingredientes { get; set; }
    }
}

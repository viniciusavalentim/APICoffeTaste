namespace APICoffeeTaste.Models
{
    public class HotDrinksModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Observacoes { get; set; }
        public List<IngredientsModel>? Ingredientes { get; set; }
    }
}

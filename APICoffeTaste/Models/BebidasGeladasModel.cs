namespace APICoffeeTaste.Models
{
    public class BebidasGeladasModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Observacoes { get; set; }
        public List<IngredientesModel>? Ingredientes { get; set; }

    }
}

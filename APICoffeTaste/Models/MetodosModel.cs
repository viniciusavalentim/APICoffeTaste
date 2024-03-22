using System.ComponentModel.DataAnnotations;

namespace APICoffeeTaste.Models
{
    public class MetodosModel
    {
        public int Id { get; set; }
        public string? Metodos { get; set; }
        public List<CafesModel>? Cafes { get; set; }
    }
}

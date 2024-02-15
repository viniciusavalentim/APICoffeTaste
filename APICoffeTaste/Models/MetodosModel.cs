using System.ComponentModel.DataAnnotations;

namespace APICoffeTaste.Models
{
    public class MetodosModel
    {
        public int Id { get; set; }
        public string? Metodos { get; set; }
        public List<CafesModel>? Cafes { get; set; }
    }
}

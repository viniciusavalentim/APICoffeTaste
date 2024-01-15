using System.ComponentModel.DataAnnotations;

namespace APICoffeTaste.Models
{
    public class MetodosModel
    {
        [Key]
        public int Id { get; set; }
        public string? Metodos { get; set; }
        public string? Variacao { get; set; }
        public float QuantidadeDeCafe { get; set; }
        public float QuantidadeDeAgua { get; set; } 
        public int Temperatura { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APICoffeTaste.Models
{
    public class CafesModel
    {
        public int Id { get; set; }
        public string? Variacao { get; set; }
        public int MetodoId { get; set; }
        [JsonIgnore]
        public MetodosModel? Metodo { get; set; }
        public ReceitasModel? Receita { get; set; }
    }
}

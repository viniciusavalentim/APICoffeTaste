using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APICoffeeTaste.Models
{
    public class ReceitasModel
    {
        public int Id { get; set; }
        public float QuantidadeDeCafe { get; set; }
        public float QuantidadeDeAgua { get; set; }
        public int Temperatura { get; set; }
        public float Granulometria { get; set; }
        public int CafeId { get; set; }
        [JsonIgnore]
        public CafesModel? Cafe { get; set; }
    }
}

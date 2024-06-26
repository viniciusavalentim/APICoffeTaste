﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICoffeeTaste.Models
{
    public class IcedDrinksModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Observacoes { get; set; }
        public List<IngredientsIcedDrinksModel>? Ingredientes { get; set; }
    }
}

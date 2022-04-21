using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;

#nullable disable

namespace creditoautomotriz.Entities.Models
{
    public partial class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre { get; set; }
    }
}

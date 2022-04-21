using System;
using System.Collections.Generic;

#nullable disable

namespace creditoautomotriz.Entities.Models
{
    public partial class Patio
    {
        public Patio()
        {
            ClientePatios = new HashSet<ClientePatio>();
            Ejecutivos = new HashSet<Ejecutivo>();
        }

        public int PatioId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NumeroPuntoVenta { get; set; }

        public virtual ICollection<ClientePatio> ClientePatios { get; set; }
        public virtual ICollection<Ejecutivo> Ejecutivos { get; set; }
    }
}

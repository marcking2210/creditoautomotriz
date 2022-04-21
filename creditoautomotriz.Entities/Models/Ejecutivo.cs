using System;
using System.Collections.Generic;

#nullable disable

namespace creditoautomotriz.Entities.Models
{
    public partial class Ejecutivo
    {
        public Ejecutivo()
        {
            SolicitudesCredito = new HashSet<SolicitudCredito>();
        }

        public int EjecutivoId { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }
        public int Edad { get; set; }
        public int PatioId { get; set; }

        public virtual Patio Patio { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudesCredito { get; set; }
    }
}

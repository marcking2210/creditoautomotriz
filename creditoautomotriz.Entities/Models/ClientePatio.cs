using System;
using System.Collections.Generic;

#nullable disable

namespace creditoautomotriz.Entities.Models
{
    public partial class ClientePatio
    {
        public ClientePatio()
        {
            SolicitudesCreditos = new HashSet<SolicitudCredito>();
        }

        public int ClientePatioId { get; set; }
        public int ClienteId { get; set; }
        public int PatioId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Patio Patio { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudesCreditos { get; set; }
    }
}

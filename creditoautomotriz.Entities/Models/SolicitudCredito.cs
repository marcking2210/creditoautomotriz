using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Entities.Models
{
    public class SolicitudCredito
    {
        public int SolicitudCreditoId { get; set; }
        public int ClientePatioId { get; set; }
        public int MesesPlazo { get; set; }
        public double ValorCuota { get; set; }
        public double ValorEntrada { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public DateTime FechaElaboracion { get; set; }
        public int EjecutivoId { get; set; }
        public int VehiculoId { get; set; }

        public virtual ClientePatio ClientePatio { get; set; }
        public virtual Ejecutivo Ejecutivo { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}

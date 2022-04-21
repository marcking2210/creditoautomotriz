using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;

#nullable disable

namespace creditoautomotriz.Entities.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            SolicitudesCredito = new HashSet<SolicitudCredito>();
        }

        public int VehiculoId { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string NumeroChasis { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public double Cilindraje { get; set; }
        public double Avaluo { get; set; }

        public virtual ICollection<SolicitudCredito> SolicitudesCredito { get; set; }
    }
}

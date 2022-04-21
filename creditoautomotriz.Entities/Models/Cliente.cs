using System;
using System.Collections.Generic;

#nullable disable

namespace creditoautomotriz.Entities.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClientePatios = new HashSet<ClientePatio>();
        }

        public int ClienteId { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public string IdentificacionConyugue { get; set; }
        public string NombresConyugue { get; set; }
        public string ApellidosConyugue { get; set; }
        public bool SujetoCredito { get; set; }

        public virtual ICollection<ClientePatio> ClientePatios { get; set; }
    }
}

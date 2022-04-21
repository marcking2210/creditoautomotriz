using creditoautomotriz.Entities;
using creditoautomotriz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface ISolicitudCreditoRepository
    {
        Task<IEnumerable<SolicitudCredito>> GetSolicitudesCredito();
        Task<SolicitudCredito> GetSolicitudCredito(int id);
        Task InsertSolicitudCredito(SolicitudCredito solicitudCredito);
        Task<bool> UpdateSolicitudCredito(int id, SolicitudCredito solicitudCredito);
        Task<bool> DeleteSolicitudCredito(int id);

    }
}

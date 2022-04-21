using creditoautomotriz.Entities;
using creditoautomotriz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface IEjecutivoRepository
    {
        Task<IEnumerable<Ejecutivo>> GetEjecutivos();
        Task<Ejecutivo> GetEjecutivo(int id);
        Task<IEnumerable<Ejecutivo>> GetEjecutivosPatio(int id);
        public void InsertEjecutivosMasivo(List<Ejecutivo> ejecutivo);
    }
}

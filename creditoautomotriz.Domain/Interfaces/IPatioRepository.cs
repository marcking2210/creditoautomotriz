using creditoautomotriz.Entities;
using creditoautomotriz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface IPatioRepository
    {
        Task<IEnumerable<Patio>> GetPatios();
        Task<Patio> GetPatio(int id);
        Task InsertPatio(Patio patio);
        Task<bool> UpdatePatio(int id, Patio patio);
        Task<bool> DeletePatio(int id);

    }
}

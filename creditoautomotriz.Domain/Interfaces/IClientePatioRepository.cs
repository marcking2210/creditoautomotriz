using creditoautomotriz.Entities;
using creditoautomotriz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface IClientePatioRepository
    {
        Task<IEnumerable<ClientePatio>> GetClientesPatios();
        Task<ClientePatio> GetClientePatio(int ClienteId, int PatioId);
        Task InsertClientePatio(ClientePatio clientePatio);
        Task<bool> UpdateClientePatio(int id, ClientePatio clientePatio);
        Task<bool> DeleteClientePatio(int id);

    }
}

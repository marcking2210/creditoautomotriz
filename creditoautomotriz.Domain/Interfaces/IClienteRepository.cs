using creditoautomotriz.Entities;
using creditoautomotriz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetCliente(int id);
        Task InsertCliente(Cliente cliente);
        Task InsertClientes(List<Cliente> clientes);
        public void InsertClientesMasivo(List<Cliente> clientes);
        Task<bool> UpdateCliente(int id, Cliente cliente);
        Task<bool> DeleteCliente(int id);
    }
}

using creditoautomotriz.Domain.Interfaces;
using creditoautomotriz.Entities;
using creditoautomotriz.Entities.Models;
using creditoautomotriz.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Repository.Repositories
{
    public class ClientePatioRepository : IClientePatioRepository
    {
        private readonly DbCreditoAutomotrizContext _context;

        public ClientePatioRepository(DbCreditoAutomotrizContext context)
        {
            _context = context;
        }

        public async Task<ClientePatio> GetClientePatio(int ClienteId, int PatioId)
        {
            try
            {
                var clientePatio = await _context.ClientePatios.Where(x => x.ClienteId == ClienteId && x.PatioId == PatioId).FirstOrDefaultAsync();
                return clientePatio;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<IEnumerable<ClientePatio>> GetClientesPatios()
        {
            try
            {
                var clientesPatios = await _context.ClientePatios.ToListAsync();
                return clientesPatios;
            }
            catch(Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task InsertClientePatio(ClientePatio clientePatio)
        {
            try
            {
                var clientePatioExistente = await _context.ClientePatios.Where(x => x.ClienteId == clientePatio.ClienteId && x.PatioId == clientePatio.PatioId).FirstOrDefaultAsync();
                if (clientePatioExistente == null)
                {
                    var cliente = await _context.Clientes.Where(x => x.ClienteId == clientePatio.ClienteId).FirstOrDefaultAsync();
                    var patio = await _context.Patios.Where(x => x.PatioId == clientePatio.PatioId).FirstOrDefaultAsync();
                    clientePatio.Cliente = cliente;
                    clientePatio.Patio = patio;
                    clientePatio.FechaAsignacion = DateTime.Now;
                    _context.ClientePatios.Add(clientePatio);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El Cliente " + clientePatio.Cliente.Nombres + " " + clientePatio.Cliente.Apellidos + " ya se encuentra asignado al patio " + clientePatio.Patio.Nombre + ".");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<bool> UpdateClientePatio(int id, ClientePatio clientePatio)
        {
            try
            {
                var clientePatioExistente = await _context.ClientePatios.Where(x => x.ClientePatioId == id).FirstOrDefaultAsync();
                if (clientePatioExistente == null)
                {
                    throw new Exception("No se encontró registro.");
                }
                else
                {
                    var cliente = await _context.Clientes.Where(x => x.ClienteId == clientePatio.ClienteId).FirstOrDefaultAsync();
                    var patio = await _context.Patios.Where(x => x.PatioId == clientePatio.PatioId).FirstOrDefaultAsync();
                    clientePatioExistente.Cliente = cliente;
                    clientePatioExistente.Patio = patio;
                    clientePatioExistente.ClienteId = clientePatio.ClienteId;
                    clientePatioExistente.PatioId = clientePatio.PatioId;
                    clientePatioExistente.FechaAsignacion = DateTime.Now;
                    _context.ClientePatios.Update(clientePatioExistente);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<bool> DeleteClientePatio(int id)
        {
            try
            {
                var clientePatioExistente = await _context.ClientePatios.Where(x => x.ClientePatioId == id).FirstOrDefaultAsync();
                if (clientePatioExistente == null)
                {
                    throw new Exception("No se encontró el registro.");
                }
                else
                {
                    _context.ClientePatios.Remove(clientePatioExistente);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }
    }
}

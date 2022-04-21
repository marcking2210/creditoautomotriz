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
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbCreditoAutomotrizContext _context;

        public ClienteRepository(DbCreditoAutomotrizContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetCliente(int id)
        {
            try
            {
                var cliente = await _context.Clientes.Where(x => x.ClienteId == id).FirstOrDefaultAsync();
                return cliente;
            }
            catch(Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            try
            {
                var clientes = await _context.Clientes.ToListAsync();
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task InsertCliente(Cliente cliente)
        {
            try
            {
                var clienteExistente = await _context.Clientes.Where(x => x.Identificacion == cliente.Identificacion).FirstOrDefaultAsync();
                if (clienteExistente == null)
                {
                    _context.Clientes.Add(cliente);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El cliente con Identificación: " + cliente.Identificacion + " ya existe.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task InsertClientes(List<Cliente> clientes)
        {
            try
            {
                foreach (var item in clientes)
                {
                    var clienteExistente = _context.Clientes.Where(x => x.Identificacion == item.Identificacion).FirstOrDefaultAsync();
                    if (clienteExistente == null)
                    {
                        _context.Clientes.Add(item);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("El cliente con Identificación: " + item.Identificacion + " ya existe.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public void InsertClientesMasivo(List<Cliente> clientes)
        {
            try
            {
                foreach (var item in clientes)
                {
                    var clienteExistente = _context.Clientes.Where(x => x.Identificacion == item.Identificacion).FirstOrDefault();
                    if (clienteExistente == null)
                    {
                        _context.Clientes.Add(item);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El cliente con Identificación: " + item.Identificacion + " ya existe.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<bool> UpdateCliente(int id, Cliente cliente)
        {
            try
            {
                var clienteExistente = await _context.Clientes.Where(x => x.ClienteId == id).FirstOrDefaultAsync();
                if (clienteExistente == null)
                {
                    throw new Exception("No se encontró el cliente.");
                }
                else
                {
                    if (clienteExistente.Identificacion != cliente.Identificacion)
                    {
                        var clienteExistenteActualizar = await _context.Clientes.Where(x => x.Identificacion == cliente.Identificacion).FirstOrDefaultAsync();
                        if (clienteExistenteActualizar == null)
                        {
                            clienteExistente.Identificacion = cliente.Identificacion;
                            clienteExistente.Nombres = cliente.Nombres;
                            clienteExistente.Apellidos = cliente.Apellidos;
                            clienteExistente.Edad = cliente.Edad;
                            clienteExistente.FechaNacimiento = cliente.FechaNacimiento;
                            clienteExistente.Direccion = cliente.Direccion;
                            clienteExistente.Telefono = cliente.Telefono;
                            clienteExistente.EstadoCivil = cliente.EstadoCivil;
                            clienteExistente.IdentificacionConyugue = cliente.IdentificacionConyugue;
                            clienteExistente.NombresConyugue = cliente.NombresConyugue;
                            clienteExistente.ApellidosConyugue = cliente.ApellidosConyugue;
                            clienteExistente.SujetoCredito = cliente.SujetoCredito;
                            _context.Clientes.Update(clienteExistente);
                            await _context.SaveChangesAsync();
                            return true;
                        }
                        else
                        {
                            throw new Exception("El cliente con Identificación: " + clienteExistenteActualizar.Identificacion + " ya existe.");
                        }
                    }
                    else
                    {
                        clienteExistente.Identificacion = cliente.Identificacion;
                        clienteExistente.Nombres = cliente.Nombres;
                        clienteExistente.Apellidos = cliente.Apellidos;
                        clienteExistente.Edad = cliente.Edad;
                        clienteExistente.FechaNacimiento = cliente.FechaNacimiento;
                        clienteExistente.Direccion = cliente.Direccion;
                        clienteExistente.Telefono = cliente.Telefono;
                        clienteExistente.EstadoCivil = cliente.EstadoCivil;
                        clienteExistente.IdentificacionConyugue = cliente.IdentificacionConyugue;
                        clienteExistente.NombresConyugue = cliente.NombresConyugue;
                        clienteExistente.ApellidosConyugue = cliente.ApellidosConyugue;
                        clienteExistente.SujetoCredito = cliente.SujetoCredito;
                        _context.Clientes.Update(clienteExistente);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<bool> DeleteCliente(int id)
        {
            try
            {
                var clienteExistente = await _context.Clientes.Where(x => x.ClienteId == id).FirstOrDefaultAsync();
                if (clienteExistente == null)
                {
                    throw new Exception("No se encontró el cliente.");
                }
                else
                {
                    _context.Clientes.Remove(clienteExistente);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

    }
}

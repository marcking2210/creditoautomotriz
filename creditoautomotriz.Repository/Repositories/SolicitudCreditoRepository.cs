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
    public class SolicitudCreditoRepository : ISolicitudCreditoRepository
    {
        private readonly DbCreditoAutomotrizContext _context;

        public SolicitudCreditoRepository(DbCreditoAutomotrizContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteSolicitudCredito(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SolicitudCredito> GetSolicitudCredito(int id)
        {
            try
            {
                var solicitudCredito = await _context.SolicitudesCreditos.Where(x => x.SolicitudCreditoId == id).FirstOrDefaultAsync();
                return solicitudCredito;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<IEnumerable<SolicitudCredito>> GetSolicitudesCredito()
        {
            try
            {
                var solicitudesCredito = await _context.SolicitudesCreditos.ToListAsync();
                return solicitudesCredito;
            }
            catch(Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task InsertSolicitudCredito(SolicitudCredito solicitudCredito)
        {
            try
            {
                var solicitudCreditoExistente = await _context.SolicitudesCreditos.Where(x => x.SolicitudCreditoId == solicitudCredito.SolicitudCreditoId).FirstOrDefaultAsync();
                if (solicitudCreditoExistente == null)
                {
                    var clientePatio = await _context.ClientePatios.Where(x => x.ClientePatioId == solicitudCredito.ClientePatioId).FirstOrDefaultAsync();
                    var cliente = await _context.Clientes.Where(x => x.ClienteId == clientePatio.ClienteId).FirstOrDefaultAsync();
                    var patio = await _context.Patios.Where(x => x.PatioId == clientePatio.PatioId).FirstOrDefaultAsync();
                    var ejecutivo = await _context.Ejecutivos.Where(x => x.EjecutivoId == solicitudCredito.EjecutivoId).FirstOrDefaultAsync();
                    var vehiculo = await _context.Vehiculos.Where(x => x.VehiculoId == solicitudCredito.VehiculoId).FirstOrDefaultAsync();
                    solicitudCredito.ClientePatio = clientePatio;
                    solicitudCredito.ClientePatio.Cliente = cliente;
                    solicitudCredito.ClientePatio.Patio = patio;
                    solicitudCredito.Ejecutivo = ejecutivo;
                    solicitudCredito.Vehiculo = vehiculo;
                    solicitudCredito.FechaElaboracion = DateTime.Now;
                    if (cliente != null)
                    {
                        var solicitudFecha = await _context.SolicitudesCreditos.Where(x => x.FechaElaboracion.Date == solicitudCredito.FechaElaboracion.Date && x.ClientePatio.Cliente.ClienteId == solicitudCredito.ClientePatio.Cliente.ClienteId).FirstOrDefaultAsync();
                        if (solicitudFecha == null)
                        {
                            var clientePatioA = await _context.ClientePatios.Where(x => x.ClientePatioId == solicitudCredito.ClientePatioId).FirstOrDefaultAsync();
                            var clienteA = await _context.Clientes.Where(x => x.ClienteId == clientePatio.ClienteId).FirstOrDefaultAsync();
                            var patioA = await _context.Patios.Where(x => x.PatioId == clientePatio.PatioId).FirstOrDefaultAsync();
                            var ejecutivoA = await _context.Ejecutivos.Where(x => x.EjecutivoId == solicitudCredito.EjecutivoId).FirstOrDefaultAsync();
                            var vehiculoA = await _context.Vehiculos.Where(x => x.VehiculoId == solicitudCredito.VehiculoId).FirstOrDefaultAsync();
                            solicitudCredito.ClientePatio = clientePatioA;
                            solicitudCredito.ClientePatio.Cliente = clienteA;
                            solicitudCredito.ClientePatio.Patio = patioA;
                            solicitudCredito.Ejecutivo = ejecutivoA;
                            solicitudCredito.Vehiculo = vehiculoA;
                            solicitudCredito.FechaElaboracion = DateTime.Now;
                            solicitudCredito.Estado = "REGISTRADA";
                            _context.SolicitudesCreditos.Add(solicitudCredito);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            throw new Exception("El cliente ya tiene una solicitud de credito este dia.");
                        }
                    }
                    else
                    {
                        var clientePatioA = await _context.ClientePatios.Where(x => x.ClientePatioId == solicitudCredito.ClientePatioId).FirstOrDefaultAsync();
                        var clienteA = await _context.Clientes.Where(x => x.ClienteId == clientePatio.ClienteId).FirstOrDefaultAsync();
                        var patioA = await _context.Patios.Where(x => x.PatioId == clientePatio.PatioId).FirstOrDefaultAsync();
                        var ejecutivoA = await _context.Ejecutivos.Where(x => x.EjecutivoId == solicitudCredito.EjecutivoId).FirstOrDefaultAsync();
                        var vehiculoA = await _context.Vehiculos.Where(x => x.VehiculoId == solicitudCredito.VehiculoId).FirstOrDefaultAsync();
                        solicitudCredito.ClientePatio = clientePatioA;
                        solicitudCredito.ClientePatio.Cliente = clienteA;
                        solicitudCredito.ClientePatio.Patio = patioA;
                        solicitudCredito.Ejecutivo = ejecutivoA;
                        solicitudCredito.Vehiculo = vehiculoA;
                        solicitudCredito.FechaElaboracion = DateTime.Now;
                        solicitudCredito.Estado = "REGISTRADA";
                        _context.SolicitudesCreditos.Add(solicitudCredito);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    throw new Exception("La solicitud de credito " + solicitudCreditoExistente.SolicitudCreditoId + " ya existe.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public Task<bool> UpdateSolicitudCredito(int id, SolicitudCredito solicitudCredito)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class PatioRepository : IPatioRepository
    {
        private readonly DbCreditoAutomotrizContext _context;

        public PatioRepository(DbCreditoAutomotrizContext context)
        {
            _context = context;
        }

        public async Task<Patio> GetPatio(int id)
        {
            try
            {
                var patio = await _context.Patios.Where(x => x.PatioId == id).FirstOrDefaultAsync();
                return patio;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Patio>> GetPatios()
        {
            try
            {
                var patios = await _context.Patios.ToListAsync();
                return patios;
            }
            catch(Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task InsertPatio(Patio patio)
        {
            try
            {
                var patioExistente = await _context.Patios.Where(x => x.Nombre == patio.Nombre).FirstOrDefaultAsync();
                if (patioExistente == null)
                {
                    _context.Patios.Add(patio);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El Patio " + patio.Nombre + " ya existe.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<bool> UpdatePatio(int id, Patio patio)
        {
            try
            {
                var patioExistente = await _context.Patios.Where(x => x.PatioId == id).FirstOrDefaultAsync();
                if (patioExistente == null)
                {
                    throw new Exception("No se encontró el patio.");
                }
                else
                {
                    if (patioExistente.Nombre != patio.Nombre)
                    {
                        var patioExistenteActualizar = await _context.Patios.Where(x => x.Nombre == patio.Nombre).FirstOrDefaultAsync();
                        if (patioExistenteActualizar == null)
                        {
                            patioExistente.Nombre = patio.Nombre;
                            patioExistente.Direccion = patio.Direccion;
                            patioExistente.Telefono = patio.Telefono;
                            patioExistente.NumeroPuntoVenta = patio.NumeroPuntoVenta;
                            _context.Patios.Update(patioExistente);
                            await _context.SaveChangesAsync();
                            return true;
                        }
                        else
                        {
                            throw new Exception("El Patio con Nombre " + patioExistente.Nombre + " ya existe.");
                        }
                    }
                    else
                    {
                        patioExistente.Nombre = patio.Nombre;
                        patioExistente.Direccion = patio.Direccion;
                        patioExistente.Telefono = patio.Telefono;
                        patioExistente.NumeroPuntoVenta = patio.NumeroPuntoVenta;
                        _context.Patios.Update(patioExistente);
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

        public async Task<bool> DeletePatio(int id)
        {
            try
            {
                var patioExistente = await _context.Patios.Where(x => x.PatioId == id).FirstOrDefaultAsync();
                if (patioExistente == null)
                {
                    throw new Exception("No se encontró el patio.");
                }
                else
                {
                    _context.Patios.Remove(patioExistente);
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

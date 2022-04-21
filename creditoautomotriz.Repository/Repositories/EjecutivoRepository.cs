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
    public class EjecutivoRepository : IEjecutivoRepository
    {
        private readonly DbCreditoAutomotrizContext _context;

        public EjecutivoRepository(DbCreditoAutomotrizContext context)
        {
            _context = context;
        }

        public async Task<Ejecutivo> GetEjecutivo(int id)
        {
            try
            {
                var ejecutivo = await _context.Ejecutivos.Where(x => x.EjecutivoId == id).FirstOrDefaultAsync();
                return ejecutivo;
            }
            catch(Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Ejecutivo>> GetEjecutivos()
        {
            try
            {
                var ejecutivos = await _context.Ejecutivos.ToListAsync();
                return ejecutivos;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Ejecutivo>> GetEjecutivosPatio(int id)
        {
            try
            {
                var ejecutivos = await _context.Ejecutivos.Where(x => x.PatioId == id).ToListAsync();
                return ejecutivos;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public void InsertEjecutivosMasivo(List<Ejecutivo> ejecutivos)
        {
            try
            {
                foreach (var item in ejecutivos)
                {
                    var ejecutivoExistente = _context.Ejecutivos.Where(x => x.Identificacion == item.Identificacion).FirstOrDefault();
                    if (ejecutivoExistente == null)
                    {
                        _context.Ejecutivos.Add(item);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El ejecutivo con Identificación: " + item.Identificacion + " ya existe.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }
    }
}

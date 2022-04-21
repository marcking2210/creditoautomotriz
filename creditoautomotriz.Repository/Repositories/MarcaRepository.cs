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
    public class MarcaRepository : IMarcaRepository
    {
        private readonly DbCreditoAutomotrizContext _context;

        public MarcaRepository(DbCreditoAutomotrizContext context)
        {
            _context = context;
        }

        public async Task<Marca> GetMarca(int id)
        {
            try
            {
                var marca = await _context.Marcas.Where(x => x.MarcaId == id).FirstOrDefaultAsync();
                return marca;
            }
            catch(Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Marca>> GetMarcas()
        {
            try
            {
                var marcas = await _context.Marcas.ToListAsync();
                return marcas;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public void InsertMarcasMasivo(List<Marca> marcas)
        {
            try
            {
                foreach (var item in marcas)
                {
                    var marcaExistente = _context.Marcas.Where(x => x.Nombre == item.Nombre).FirstOrDefault();
                    if (marcaExistente == null)
                    {
                        _context.Marcas.Add(item);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("La marca " + item.Nombre + " ya existe.");
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

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
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly DbCreditoAutomotrizContext _context;

        public VehiculoRepository(DbCreditoAutomotrizContext context)
        {
            _context = context;
        }

        public async Task<Vehiculo> GetVehiculo(int id)
        {
            try
            {
                var vehiculo = await _context.Vehiculos.Where(x => x.VehiculoId == id).FirstOrDefaultAsync();
                return vehiculo;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculos()
        {
            try
            {
                var vehiculos = await _context.Vehiculos.ToListAsync();
                return vehiculos;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task InsertVehiculo(Vehiculo vehiculo)
        {
            try
            {
                var vehiculoExistente = await _context.Vehiculos.Where(x => x.Placa == vehiculo.Placa).FirstOrDefaultAsync();
                if (vehiculoExistente == null)
                {
                    _context.Vehiculos.Add(vehiculo);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El vehiculo con placa " + vehiculo.Placa + " ya existe.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }
        }

        public async Task<bool> UpdateVehiculo(int id, Vehiculo vehiculo)
        {
            try
            {
                var vehiculoExistente = await _context.Vehiculos.Where(x => x.VehiculoId == id).FirstOrDefaultAsync();
                if (vehiculoExistente == null)
                {
                    throw new Exception("No se encontró el vehículo.");
                }
                else
                {
                    if (vehiculoExistente.Placa != vehiculo.Placa)
                    {
                        var vehiculoExistenteActualizar = await _context.Vehiculos.Where(x => x.Placa == vehiculo.Placa).FirstOrDefaultAsync();
                        if (vehiculoExistenteActualizar == null)
                        {
                            vehiculoExistente.Placa = vehiculo.Placa;
                            vehiculoExistente.Modelo = vehiculo.Modelo;
                            vehiculoExistente.NumeroChasis = vehiculo.NumeroChasis;
                            vehiculoExistente.Marca = vehiculo.Marca;
                            vehiculoExistente.Tipo = vehiculo.Tipo;
                            vehiculoExistente.Cilindraje = vehiculo.Cilindraje;
                            vehiculoExistente.Avaluo = vehiculo.Avaluo;
                            _context.Vehiculos.Update(vehiculoExistente);
                            await _context.SaveChangesAsync();
                            return true;
                        }
                        else
                        {
                            throw new Exception("El vehiculo con Placa " + vehiculoExistenteActualizar.Placa + " ya existe.");
                        }
                    }
                    else
                    {
                        vehiculoExistente.Placa = vehiculo.Placa;
                        vehiculoExistente.Modelo = vehiculo.Modelo;
                        vehiculoExistente.NumeroChasis = vehiculo.NumeroChasis;
                        vehiculoExistente.Marca = vehiculo.Marca;
                        vehiculoExistente.Tipo = vehiculo.Tipo;
                        vehiculoExistente.Cilindraje = vehiculo.Cilindraje;
                        vehiculoExistente.Avaluo = vehiculo.Avaluo;
                        _context.Vehiculos.Update(vehiculoExistente);
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

        public async Task<bool> DeleteVehiculo(int id)
        {
            try
            {
                var vehiculoExistente = await _context.Vehiculos.Where(x => x.VehiculoId == id).FirstOrDefaultAsync();
                if (vehiculoExistente == null)
                {
                    throw new Exception("No se encontró el vehículo.");
                }
                else
                {
                    _context.Vehiculos.Remove(vehiculoExistente);
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

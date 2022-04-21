using creditoautomotriz.Domain.Interfaces;
using creditoautomotriz.Entities;
using creditoautomotriz.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.API.Controllers
{
    [Route("api/creditoautomotriz/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        public VehiculosController(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        [HttpGet, Route("obtener-vehiculos")]
        public IActionResult GetVehiculos()
        {
            try
            {
                var vehiculos = _vehiculoRepository.GetVehiculos();
                return Ok(vehiculos);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetVehiculo(int id)
        {
            try
            {
                var vehiculo = _vehiculoRepository.GetVehiculo(id);
                return Ok(vehiculo);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Vehiculo vehiculo)
        {
            try
            {
                await _vehiculoRepository.InsertVehiculo(vehiculo);
                return Ok(vehiculo);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Vehiculo vehiculo)
        {
            try
            {
                await _vehiculoRepository.UpdateVehiculo(id, vehiculo);
                var vehiculoActualizado = _vehiculoRepository.GetVehiculo(id);
                return Ok(vehiculoActualizado);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vehiculoRepository.DeleteVehiculo(id);
                var vehiculos = _vehiculoRepository.GetVehiculos();
                return Ok(vehiculos);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

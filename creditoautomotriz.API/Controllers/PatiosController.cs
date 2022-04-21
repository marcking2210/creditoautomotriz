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
    public class PatiosController : ControllerBase
    {
        private readonly IPatioRepository _patioRepository;
        public PatiosController(IPatioRepository patioRepository)
        {
            _patioRepository = patioRepository;
        }

        [HttpGet, Route("obtener-patios")]
        public IActionResult GetPatios()
        {
            try
            {
                var patios = _patioRepository.GetPatios();
                return Ok(patios);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPatio(int id)
        {
            try
            {
                var patio = _patioRepository.GetPatio(id);
                return Ok(patio);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Patio patio)
        {
            try
            {
                await _patioRepository.InsertPatio(patio);
                return Ok(patio);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Patio patio)
        {
            try
            {
                await _patioRepository.UpdatePatio(id, patio);
                var patioActualizado = _patioRepository.GetPatio(id);
                return Ok(patioActualizado);
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
                await _patioRepository.DeletePatio(id);
                var vehiculos = _patioRepository.GetPatios();
                return Ok(vehiculos);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

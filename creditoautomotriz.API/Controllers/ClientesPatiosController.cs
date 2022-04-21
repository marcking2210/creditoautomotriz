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
    public class ClientesPatiosController : ControllerBase
    {
        private readonly IClientePatioRepository _clientePatioRepository;
        public ClientesPatiosController(IClientePatioRepository clientePatioRepository)
        {
            _clientePatioRepository = clientePatioRepository;
        }

        [HttpGet, Route("obtener-clientespatios")]
        public IActionResult GetClientesPatios()
        {
            try
            {
                var clientesPatios = _clientePatioRepository.GetClientesPatios();
                return Ok(clientesPatios);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClientePatio(int ClienteId, int PatioId)
        {
            try
            {
                var patio = _clientePatioRepository.GetClientePatio(ClienteId, PatioId);
                return Ok(patio);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(ClientePatio clientePatio)
        {
            try
            {
                await _clientePatioRepository.InsertClientePatio(clientePatio);
                return Ok(clientePatio);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClientePatio clientePatio)
        {
            try
            {
                await _clientePatioRepository.UpdateClientePatio(id, clientePatio);
                var clientePatioActualizado = _clientePatioRepository.GetClientePatio(clientePatio.ClienteId, clientePatio.PatioId);
                return Ok(clientePatioActualizado);
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
                await _clientePatioRepository.DeleteClientePatio(id);
                var clientesPatios = _clientePatioRepository.GetClientesPatios();
                return Ok(clientesPatios);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

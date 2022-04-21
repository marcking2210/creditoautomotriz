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
    public class SolicitudesCreditoController : ControllerBase
    {
        private readonly ISolicitudCreditoRepository _solicitudCreditoRepository;
        public SolicitudesCreditoController(ISolicitudCreditoRepository solicitudCreditoRepository)
        {
            _solicitudCreditoRepository = solicitudCreditoRepository;
        }

        [HttpGet, Route("obtener-solicitudescredito")]
        public IActionResult GetSolicitudesCredito()
        {
            try
            {
                var solicitudesCredito = _solicitudCreditoRepository.GetSolicitudesCredito();
                return Ok(solicitudesCredito);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSolicitudCredito(int id)
        {
            try
            {
                var patio = _solicitudCreditoRepository.GetSolicitudCredito(id);
                return Ok(patio);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(SolicitudCredito solicitudCredito)
        {
            try
            {
                await _solicitudCreditoRepository.InsertSolicitudCredito(solicitudCredito);
                return Ok(solicitudCredito);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

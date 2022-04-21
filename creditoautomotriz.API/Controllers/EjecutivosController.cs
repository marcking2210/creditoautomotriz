using creditoautomotriz.Domain.Interfaces;
using creditoautomotriz.Entities;
using creditoautomotriz.Entities.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.API.Controllers
{
    [Route("api/creditoautomotriz/[controller]")]
    [ApiController]
    public class EjecutivosController : ControllerBase
    {
        private readonly IEjecutivoRepository _ejecutivoRepository;

        public ActionResult InsertarEjecutivosMasivo()
        {
            try
            {
                String path = "C:\\Users\\ALIENWARE\\Postman\\files\\Ejecutivos.csv";
                List<Ejecutivo> ejecutivos = new List<Ejecutivo>();
                List<string> lineasArchivo = new List<string>();
                using (var stream = new StreamReader(path))
                {
                    while (!stream.EndOfStream)
                    {
                        var linea = stream.ReadLine();
                        lineasArchivo.Add(linea);
                    }

                    foreach (var item in lineasArchivo.Skip(1))
                    {
                        var cells = item.Split(";");
                        var ejecutivo = new Ejecutivo();
                        ejecutivo.Identificacion = cells[0];
                        ejecutivo.Nombres = cells[1];
                        ejecutivo.Apellidos = cells[2];
                        ejecutivo.Direccion = cells[3];
                        ejecutivo.TelefonoConvencional = cells[4];
                        ejecutivo.TelefonoCelular = cells[5];
                        ejecutivo.Edad = Convert.ToInt32(cells[6]);
                        ejecutivo.PatioId = Convert.ToInt32(cells[7]);
                        ejecutivos.Add(ejecutivo);
                    }

                    _ejecutivoRepository.InsertEjecutivosMasivo(ejecutivos);
                    return Ok("Ejecutivos cargados exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        public EjecutivosController(IEjecutivoRepository ejecutivoRepository)
        {
            _ejecutivoRepository = ejecutivoRepository;
            InsertarEjecutivosMasivo();
        }

        [HttpGet, Route("obtener-ejecutivos")]
        public IActionResult GetEjecutivos()
        {
            try
            {
                var ejecutivos= _ejecutivoRepository.GetEjecutivos();
                return Ok(ejecutivos);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEjecutivo(int id)
        {
            try
            {
                var ejecutivo = _ejecutivoRepository.GetEjecutivo(id);
                return Ok(ejecutivo);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet, Route("obtener-ejecutivospatio/{id}")]
        public IActionResult GetEjecutivosPatio(int id)
        {
            try
            {
                var ejecutivo = _ejecutivoRepository.GetEjecutivosPatio(id);
                return Ok(ejecutivo);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

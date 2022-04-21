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
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaRepository _marcaRepository;

        public ActionResult InsertarMarcasMasivo()
        {
            try
            {
                String path = "C:\\Users\\ALIENWARE\\Postman\\files\\Marcas.csv";
                List<Marca> marcas = new List<Marca>();
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
                        var marca = new Marca();
                        marca.Nombre = cells[0];
                        marcas.Add(marca);

                    }

                    _marcaRepository.InsertMarcasMasivo(marcas);
                    return Ok("Marcas cargadas exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        public MarcasController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
            InsertarMarcasMasivo();
        }

        [HttpGet, Route("obtener-marcas")]
        public IActionResult GetMarcas()
        {
            try
            {
                var marcas= _marcaRepository.GetMarcas();
                return Ok(marcas);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMarca(int id)
        {
            try
            {
                var marca = _marcaRepository.GetMarca(id);
                return Ok(marca);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

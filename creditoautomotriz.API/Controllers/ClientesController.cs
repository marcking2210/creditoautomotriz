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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ActionResult InsertarClientesMasivo()
        {
            try
            {
                String path = "C:\\Users\\ALIENWARE\\Postman\\files\\Clientes.csv";
                List<Cliente> clientes = new List<Cliente>();
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
                        var cliente = new Cliente();
                        cliente.Identificacion = cells[0];
                        cliente.Nombres = cells[1];
                        cliente.Apellidos = cells[2];
                        cliente.Edad = Convert.ToInt32(cells[3]);
                        cliente.FechaNacimiento = Convert.ToDateTime(cells[4]);
                        cliente.Direccion = cells[5];
                        cliente.Telefono = cells[6];
                        cliente.EstadoCivil = cells[7];
                        cliente.IdentificacionConyugue = cells[8];
                        cliente.NombresConyugue = cells[9];
                        cliente.ApellidosConyugue = cells[10];
                        if (cells[11].Equals("S"))
                        {
                            cliente.SujetoCredito = true;
                        }
                        else
                        {
                            cliente.SujetoCredito = false;
                        }
                        clientes.Add(cliente);
                    }

                    _clienteRepository.InsertClientesMasivo(clientes);
                    return Ok("Clientes cargados exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            InsertarClientesMasivo();
        }

        [HttpGet, Route("obtener-clientes")]
        public IActionResult GetClientes()
        {
            try
            {
                var clientes = _clienteRepository.GetClientes();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            try
            {
                var cliente = _clienteRepository.GetCliente(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            try
            {
                await _clienteRepository.InsertCliente(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("UploadFiles"), Route("cargar-archivo")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>(); ;
                List<string> lineasArchivo = new List<string>();
                if (file.FileName.EndsWith(".csv"))
                {
                    using (var stream = new StreamReader(file.OpenReadStream()))
                    {
                        while (!stream.EndOfStream)
                        {
                            var linea = stream.ReadLine();
                            lineasArchivo.Add(linea);
                        }

                        foreach (var item in lineasArchivo.Skip(1))
                        {
                            var cells = item.Split(";");
                            var cliente = new Cliente();
                            cliente.Identificacion = cells[0];
                            cliente.Nombres = cells[1];
                            cliente.Apellidos = cells[2];
                            cliente.Edad = Convert.ToInt32(cells[3]);
                            cliente.FechaNacimiento = Convert.ToDateTime(cells[4]);
                            cliente.Direccion = cells[5];
                            cliente.Telefono = cells[6];
                            cliente.EstadoCivil = cells[7];
                            cliente.IdentificacionConyugue = cells[8];
                            cliente.NombresConyugue = cells[9];
                            cliente.ApellidosConyugue = cells[10];
                            if (cells[11].Equals("S"))
                            {
                                cliente.SujetoCredito = true;
                            }
                            else
                            {
                                cliente.SujetoCredito = false;
                            }
                            clientes.Add(cliente);
                        }

                        await _clienteRepository.InsertClientes(clientes);

                    }
                    return Ok("Datos cargados exitosamente.");

                }
                else
                {
                    return Ok("Los datos no se cargaron.");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente cliente)
        {
            try
            {
                await _clienteRepository.UpdateCliente(id, cliente);
                var clienteActualizado = _clienteRepository.GetCliente(id);
                return Ok(clienteActualizado);
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
                await _clienteRepository.DeleteCliente(id);
                var clientes = _clienteRepository.GetClientes();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

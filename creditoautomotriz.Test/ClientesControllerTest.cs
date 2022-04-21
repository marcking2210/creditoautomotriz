using creditoautomotriz.API.Controllers;
using creditoautomotriz.Domain.Interfaces;
using creditoautomotriz.Entities.Models;
using creditoautomotriz.Infrastructure;
using creditoautomotriz.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace creditoautomotriz.Test
{
    public class ClientesControllerTest
    {
        private readonly ClientesController _controller;
        private readonly IClienteRepository _clienteRepository;
        private readonly DbCreditoAutomotrizContext _dbContext;

        public ClientesControllerTest()
        {
            _dbContext = new DbCreditoAutomotrizContext();
            _clienteRepository = new ClienteRepository(_dbContext);
            _controller = new ClientesController(_clienteRepository);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetClientes() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Cliente>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetCliente(1);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Cliente()
            {
                Identificacion = "1717586893",
                Nombres = "Marco Antonio",
                Apellidos = "Jativa Baldeon",
                Edad = 36,
                FechaNacimiento = Convert.ToDateTime("1985-10-22"),
                Direccion = "Conocoto",
                Telefono = "0995302659",
                EstadoCivil = "S",
                IdentificacionConyugue = "",
                NombresConyugue = "",
                ApellidosConyugue = "",
                SujetoCredito = true
            };
            _controller.ModelState.AddModelError("Identificacion", "Required");
            _controller.ModelState.AddModelError("Nombres", "Required");
            _controller.ModelState.AddModelError("Apellidos", "Required");
            _controller.ModelState.AddModelError("Edad", "Required");
            _controller.ModelState.AddModelError("Direccion", "Required");
            _controller.ModelState.AddModelError("Telefono", "Required");
            _controller.ModelState.AddModelError("EstadoCivil", "Required");
            _controller.ModelState.AddModelError("SujetoCredito", "Required");
            // Act
            var badResponse = _controller.Post(nameMissingItem);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = 1;
            // Act
            var badResponse = _controller.Delete(notExistingGuid);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

    }
}

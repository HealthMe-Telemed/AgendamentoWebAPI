using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Controllers;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AgendamentoWebAPI.Tests.ControllerTests
{
    public class MedicosControllerTest
    {
        [Fact]
        public async void BuscarMedicosSemFiltroSucesso()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<MedicosController>>();
            var medicoServiceMock = new Mock<IMedicoService>();
            int idEspecialidade = 0;
            int idMedico = 3;
            List<Medico> medicosMock = new List<Medico>(){
                new Medico() {Id = 1, Nome = "Medico1", CRM = "11111111", CRP = "1111111"},
                new Medico() {Id = 2, Nome = "Medico2", CRM = "22222222", CRP = "2222222"}
            };
            medicoServiceMock.Setup(s => s.EncontrarMedicos(idMedico)).ReturnsAsync(medicosMock);
            var controller = new MedicosController(loggerMock.Object, medicoServiceMock.Object);
            
            // Act

            var result = await controller.GetMedicos(idEspecialidade, idMedico);

            // Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void BuscarMedicosComFiltroSucesso()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<MedicosController>>();
            var medicoServiceMock = new Mock<IMedicoService>();
            int idEspecialidade = 1;
            int idMedico = 3;
            List<Medico> medicosMock = new List<Medico>(){
                new Medico() {Id = 1, Nome = "Medico1", CRM = "11111111", CRP = "1111111"},
                new Medico() {Id = 2, Nome = "Medico2", CRM = "22222222", CRP = "2222222"}
            };
            medicoServiceMock.Setup(s => s.EncontrarMedicosPorEspecialidade(idEspecialidade, idMedico)).ReturnsAsync(medicosMock);
            var controller = new MedicosController(loggerMock.Object, medicoServiceMock.Object);
            
            // Act

            var result = await controller.GetMedicos(idEspecialidade, idMedico);

            // Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void BuscarMedicosSemFiltroListaVazia()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<MedicosController>>();
            var medicoServiceMock = new Mock<IMedicoService>();
            int idEspecialidade = 0;
            int idMedico = 3;
            List<Medico> medicosMock = new List<Medico>();
            medicoServiceMock.Setup(s => s.EncontrarMedicos(idMedico)).ReturnsAsync(medicosMock);
            var controller = new MedicosController(loggerMock.Object, medicoServiceMock.Object);
            
            // Act

            var result = await controller.GetMedicos(idEspecialidade, idMedico);

            // Assert

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void BuscarMedicosComFiltroListaVazia()
        {
            // Arrange
            
            var loggerMock = new Mock<ILogger<MedicosController>>();
            var medicoServiceMock = new Mock<IMedicoService>();
            int idEspecialidade = 1;
            int idMedico = 3;
            List<Medico> medicosMock = new List<Medico>();
            medicoServiceMock.Setup(s => s.EncontrarMedicosPorEspecialidade(idEspecialidade, idMedico)).ReturnsAsync(medicosMock);
            var controller = new MedicosController(loggerMock.Object, medicoServiceMock.Object);
            
            // Act

            var result = await controller.GetMedicos(idEspecialidade, idMedico);

            // Assert

            Assert.IsType<NoContentResult>(result);
        }
    }
}
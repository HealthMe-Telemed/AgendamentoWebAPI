using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.Extensions.Logging;

namespace AgendamentoWebAPI.Controllers
{
    [ApiController]
    [Route("agendamentos")]
    public class AgendamentoController : Controller
    {
        private readonly ILogger<AgendamentoController> _logger;

        private readonly IAgendamentoService _agendamentoService;

        public AgendamentoController(ILogger<AgendamentoController> logger, IAgendamentoService agendamentoService)
        {
            _logger = logger;
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        [Route("paciente/{idPaciente}")]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> GetAgendamentosPaciente(int idPaciente)
        {

            var agendamentos = await _agendamentoService.EncontrarAgendamentosPaciente(idPaciente);

            if (agendamentos.Count == 0) return NotFound("Não há agendamentos a serem listados");

            return Ok(agendamentos);
        }

        [HttpGet]
        [Route("medico/{idMedico}")]
        [Authorize(Roles = "Medico")]
        public async Task<IActionResult> GetAgendamentosMedico(int idMedico)
        {

            var agendamentos = await _agendamentoService.EncontrarAgendamentosMedico(idMedico);

            if (agendamentos.Count == 0) return NotFound("Não há agendamentos a serem listados");

            return Ok(agendamentos);
        }


        [HttpPost]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> PostAgendamento([FromBody] AgendamentoForm agendamentoForm){
            var agendamentoRealizado = await _agendamentoService.CadastrarAgendamento(agendamentoForm);
            
            if(!agendamentoRealizado) return BadRequest("Não foi possível cadastrar o agendamento");
            return Ok("Agendamento realizado com sucesso!");
        }

        [HttpDelete]
        [Route("{idAgendamento}")]
        [Authorize(Roles = "Paciente,Medico")]
        public async Task<IActionResult> CancelarAgendamento(int idAgendamento)
        {

            var agendamentoCancelado = await _agendamentoService.CancelarAgendamento(idAgendamento);

            if (!agendamentoCancelado) return BadRequest("Não foi possível cancelar o agendamento");

            return Ok("Agendamento cancelado com sucesso");
        }
    }
}
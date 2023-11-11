using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        //[Authorize(Roles = "Paciente")]
        public async Task<IActionResult> GetAgendamentos(int idPaciente)
        {

            var agendamentos = await _agendamentoService.EncontrarAgendamentos(idPaciente);

            if (agendamentos.Count == 0) return BadRequest("Não há agendamentos a serem listados");

            return Ok(agendamentos);
        }


    }
}
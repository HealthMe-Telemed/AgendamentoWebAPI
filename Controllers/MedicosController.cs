using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MedicoEspecialidadeWebAPI.Models;
using MedicoEspecialidadeWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedicoEspecialidadeWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicosController : Controller
    {
        private readonly ILogger<MedicosController> _logger;

        private readonly IMedicoService _medicoService;

        public MedicosController(ILogger<MedicosController> logger, IMedicoService medicoService)
        {
            _logger = logger;
            _medicoService = medicoService;
        }

        [HttpGet]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> GetMedicos(int idEspecialidade)
        {
            List<Medico> medicos = new List<Medico>();

            if (idEspecialidade == 0)
            {
                medicos = await _medicoService.EncontrarMedicos();
            }
            else
            {
                medicos = await _medicoService.EncontrarMedicosPorEspecialidade(idEspecialidade);
            }

            if (medicos.Count == 0) return NoContent();

            return Ok(medicos);
        }


    }
}
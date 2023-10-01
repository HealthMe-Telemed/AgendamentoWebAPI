using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoEspecialidadeWebAPI.Models;
using MedicoEspecialidadeWebAPI.Repository;

namespace MedicoEspecialidadeWebAPI.Services
{
    
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoDatabase _medicoDatabase;
        public MedicoService(IMedicoDatabase medicoDatabase)
        {
            _medicoDatabase = medicoDatabase;
        }
        public async Task<List<Medico>> EncontrarMedicos()
        {
            var medicos = await _medicoDatabase.EncontrarMedicos();
            return medicos;
        }

        public async Task<List<Medico>> EncontrarMedicosPorEspecialidade(int idEspecialidade)
        {
            var medicos = await _medicoDatabase.EncontrarMedicoPorEspecialidade(idEspecialidade);
            return medicos;
        }
    }
}
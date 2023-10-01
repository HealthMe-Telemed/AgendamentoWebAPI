using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoEspecialidadeWebAPI.Models;

namespace MedicoEspecialidadeWebAPI.Repository
{
    public interface IMedicoDatabase
    {
        public Task<List<Medico>> EncontrarMedicoPorEspecialidade(int idEspecialidade);
        public Task<List<Medico>> EncontrarMedicos();
    }
}
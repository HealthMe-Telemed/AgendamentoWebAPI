using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoEspecialidadeWebAPI.Models;

namespace MedicoEspecialidadeWebAPI.Services
{
    public interface IEspecialidadesService
    {
        public Task<List<Especialidade>> EncontrarEspecialidades();
        public Task<List<Especialidade>> EncontrarEspecialidadesPorMedico(int idMedico); 
    }
}
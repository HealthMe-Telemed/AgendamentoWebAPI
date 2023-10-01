using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoEspecialidadeWebAPI.Models;
using MedicoEspecialidadeWebAPI.Repository;

namespace MedicoEspecialidadeWebAPI.Services
{
    
    public class EspecialidadesService : IEspecialidadesService
    {
        private readonly IEspecialidadesDatabase _especialidadesDatabase;
        public EspecialidadesService(IEspecialidadesDatabase especialidadesDatabase)
        {
            _especialidadesDatabase = especialidadesDatabase;
        }
        public async Task<List<Especialidade>> EncontrarEspecialidades()
        {
            var especialidades = await _especialidadesDatabase.EncontrarEspecialidades();
            return especialidades;
        }

        public async Task<List<Especialidade>> EncontrarEspecialidadesPorMedico(int idMedico)
        {
            var especialidades = await _especialidadesDatabase.EncontrarEspecialidadesPorMedico(idMedico);
            return especialidades;
        }
    }
}
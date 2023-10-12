using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoWebAPI.Services
{
    public interface IDataHoraAgendamentoService
    {
        public Task<List<DateTime>> BuscarDataHoraDisponiveis(int idPaciente, int idMedico);
    }
}
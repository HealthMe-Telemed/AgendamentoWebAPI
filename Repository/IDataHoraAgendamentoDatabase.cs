using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoWebAPI.Repository
{
    public interface IDataHoraAgendamentoDatabase
    {
        public Task<List<DateTime>> BuscarDataHoraDisponiveis(int idPaciente, int idMedico, DateTime data);
    }
}
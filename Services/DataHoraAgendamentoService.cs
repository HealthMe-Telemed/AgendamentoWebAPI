using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Repository;

namespace AgendamentoWebAPI.Services
{
    public class DataHoraAgendamentoService : IDataHoraAgendamentoService
    {
        private readonly IDataHoraAgendamentoDatabase _dataHoraDatabase;
        public DataHoraAgendamentoService(IDataHoraAgendamentoDatabase dataHoraDatabase)
        {
            _dataHoraDatabase = dataHoraDatabase;
        }
        
        public async Task<List<DateTime>> BuscarDataHoraDisponiveis(int idPaciente, int idMedico)
        {
            var amanha = DateTime.Now.Date.AddDays(1);
            
            var dataHoraDisponiveis = await _dataHoraDatabase.BuscarDataHoraDisponiveis(idPaciente, idMedico, amanha);

            return dataHoraDisponiveis;
        }
    }
}
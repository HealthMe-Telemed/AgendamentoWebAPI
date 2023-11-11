using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Repository;

namespace AgendamentoWebAPI.Services
{
    
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoDatabase _agendamentoDatabase;
        public AgendamentoService(IAgendamentoDatabase agendamentoDatabase)
        {
            _agendamentoDatabase = agendamentoDatabase;
        }
        public async Task<List<Agendamento>> EncontrarAgendamentos(int idPaciente)
        {
            var agendamentos = await _agendamentoDatabase.EncontrarAgendamentos(idPaciente);
            return agendamentos;
        }
    }
}
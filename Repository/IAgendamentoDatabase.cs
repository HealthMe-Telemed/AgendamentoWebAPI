using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;

namespace AgendamentoWebAPI.Repository
{
    public interface IAgendamentoDatabase
    {
        public Task<List<Agendamento>> EncontrarAgendamentos(int idPaciente);
        public Task<bool> CadastrarAgendamento(AgendamentoForm agendamentoForm);
    }
}
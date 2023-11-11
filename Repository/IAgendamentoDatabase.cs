using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;

namespace AgendamentoWebAPI.Repository
{
    public interface IAgendamentoDatabase
    {
        public Task<List<Agendamento>> EncontrarAgendamentosPaciente(int idPaciente);
        public Task<List<Agendamento>> EncontrarAgendamentosMedico(int idMedico);
        public Task<bool> CadastrarAgendamento(AgendamentoForm agendamentoForm);
        Task<bool> CancelarAgendamento(int idAgendamento);
    }
}
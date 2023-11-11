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
        //private readonly ITipoConsultaDatabase _tipoConsultaDatabase;
        public AgendamentoService()
        {
            //_tipoConsultaDatabase = tipoConsultaDatabase;
        }
        public async Task<List<Agendamento>> EncontrarAgendamentos(int idPaciente)
        {
            //var tiposConsulta = await _tipoConsultaDatabase.EncontrarTiposConsulta(idMedico);
            //return tiposConsulta;
            return new List<Agendamento>();
        }
    }
}
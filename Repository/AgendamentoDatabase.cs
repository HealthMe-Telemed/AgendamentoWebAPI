using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using AgendamentoWebAPI.Extensions;
using AgendamentoWebAPI.Models;
using MySqlConnector;

namespace AgendamentoWebAPI.Repository
{
    public class AgendamentoDatabase : IAgendamentoDatabase
    {
        private readonly MySqlConnection _database;
        private readonly ILogger<AgendamentoDatabase> _logger;
        
        public AgendamentoDatabase(MySqlConnection database, ILogger<AgendamentoDatabase> logger)
        {
            _database = database;
            _logger = logger;
        }
        
        public async Task<List<Agendamento>> EncontrarAgendamentos(int idPaciente)
        {
            try
            {
                _logger.LogInformation($"Buscando agendamentos para o paciente com id {idPaciente}...");
                
                var agendamentos = await _database.QueryAsync<Agendamento>(QueryExtensions.BuscarAgendamentos(),
                new { idPaciente });
                return agendamentos.ToList();
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;

namespace AgendamentoWebAPI.Repository
{
    public class DataHoraAgendamentoDatabase : IDataHoraAgendamentoDatabase
    {
        private readonly MySqlConnection _database;
        private readonly ILogger<DataHoraAgendamentoDatabase> _logger;

        public DataHoraAgendamentoDatabase(MySqlConnection database, ILogger<DataHoraAgendamentoDatabase> logger)
        {
            _database = database;
            _logger = logger;
        }
        public async Task<List<DateTime>> BuscarDataHoraDisponiveis(int idPaciente, int idMedico, DateTime data)
        {
            try
            {
                _logger.LogInformation($"Buscando Horários Disponíveis...");
                
                var horarios = await _database.QueryAsync<DateTime>("pVerificarHorariosDisponiveis",
                new { PacienteId = idPaciente, MedicoId = idMedico, DataInicial = data},
                commandType: CommandType.StoredProcedure);
                return horarios.ToList();
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }
    }
}
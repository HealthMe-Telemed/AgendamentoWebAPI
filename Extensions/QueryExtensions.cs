using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoWebAPI.Extensions
{
    public static class QueryExtensions
    {
        public static string QueryConsultaEspecialidade() => @"
        SELECT 
            E.id as 'Id', 
            E.descricao as 'NomeEspecialidade'
            FROM especialidade E;";

        public static string QueryConsultaEspecialidadePorId() => @"
        SELECT E.id as 'Id', E.descricao as 'NomeEspecialidade' FROM especialidade E
            INNER JOIN alocacao_especialidade AE
            ON AE.espec_id = E.id
            WHERE AE.medico_id = @idMedico;";

        public static string QueryConsultaMedico() => @"
        SELECT * FROM v_medico where v_medico.Id != @idMedico";

        public static string QueryConsultaMedicoPorId() => @"
        SELECT * FROM v_medico VM
            INNER JOIN alocacao_especialidade AE
            ON VM.Id = AE.medico_id
            WHERE AE.espec_id = @idEspecialidade AND VM.Id != @idMedico;";
            
        public static string QueryConsultaTipoConsulta() => @"
        SELECT TC.id AS 'Id', TC.descricao AS 'Descricao' FROM tipo_consulta TC
          INNER JOIN alocacao_tipo_consulta ATC
          ON ATC.tipo_id = TC.id
          WHERE ATC.medico_id = @idMedico;";

        public static string BuscarAgendamentosPaciente() => @"
        SELECT A.id AS 'Id', A.medico_id AS 'MedicoId', VM.nome AS 'NomeMedico', A.paciente_id AS 'PacienteId', VP.nome AS 'NomePaciente', A.especialidade_id AS 'EspecialidadeId', E.descricao AS 'Especialidade', A.tipo_consulta_id AS 'TipoConsultaId', TC.descricao AS 'TipoConsulta', A.status_id AS 'StatusConsultaId', S.descricao AS 'StatusConsulta', A.data_agendada AS 'DataAgendamento' FROM agendamento A
            INNER JOIN v_medico VM ON VM.id = A.medico_id
            INNER JOIN especialidade E ON E.id = A.especialidade_id
            INNER JOIN v_paciente VP ON VP.IdPaciente = A.paciente_id
            INNER JOIN tipo_consulta TC ON TC.id = A.tipo_consulta_id
            INNER JOIN status S ON S.id = A.status_id
            WHERE VP.IdPaciente = @idPaciente
            ORDER BY A.data_agendada DESC;";

        public static string BuscarAgendamentosMedico() => @"
        SELECT A.id AS 'Id', A.medico_id AS 'MedicoId', VM.nome AS 'NomeMedico', A.paciente_id AS 'PacienteId', VP.nome AS 'NomePaciente', A.especialidade_id AS 'EspecialidadeId', E.descricao AS 'Especialidade', A.tipo_consulta_id AS 'TipoConsultaId', TC.descricao AS 'TipoConsulta', A.status_id AS 'StatusConsultaId', S.descricao AS 'StatusConsulta', A.data_agendada AS 'DataAgendamento' FROM agendamento A
            INNER JOIN v_medico VM ON VM.id = A.medico_id
            INNER JOIN especialidade E ON E.id = A.especialidade_id
            INNER JOIN v_paciente VP ON VP.IdPaciente = A.paciente_id
            INNER JOIN tipo_consulta TC ON TC.id = A.tipo_consulta_id
            INNER JOIN status S ON S.id = A.status_id
            WHERE VM.id = @idMedico
            ORDER BY A.data_agendada DESC;";

        public static string InserirAgendamento() => @"
        INSERT INTO agendamento(medico_id, paciente_id, especialidade_id, tipo_consulta_id, status_id, data_agendada)
        VALUES(@medicoId, @pacienteId, @especialidadeId, @tipoConsultaId, @statusId, @dataAgendada);";

        public static string CancelarAgendamento() => @"
        UPDATE agendamento SET status_id = 3 WHERE status_id = 1 AND id = @agendamentoId;";
    }

}
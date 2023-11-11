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
        SELECT * FROM v_medico;";

        public static string QueryConsultaMedicoPorId() => @"
        SELECT * FROM v_medico VM
            INNER JOIN alocacao_especialidade AE
            ON VM.Id = AE.medico_id
            WHERE AE.espec_id = @idEspecialidade;";
            
        public static string QueryConsultaTipoConsulta() => @"
        SELECT TC.id AS 'Id', TC.descricao AS 'Descricao' FROM tipo_consulta TC
          INNER JOIN alocacao_tipo_consulta ATC
          ON ATC.tipo_id = TC.id
          WHERE ATC.medico_id = @idMedico;";
    }
}
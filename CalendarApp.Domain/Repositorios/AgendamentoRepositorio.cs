using CalendarApp.Domain.Interfaces;
using CalendarApp.Infra.Interfaces;
using CalendarApp.Models.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CalendarApp.Domain.Repositorios
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private IConexao _Conexao;

        public AgendamentoRepositorio(IConexao Conexao)
        {
            _Conexao = Conexao;
        }

        public Agendamento Alterar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> Listar()
        {
            try
            {
                using (var Db = _Conexao.AbrirConexao())
                {
                    return Db.Query<Agendamento>("spListarAgendamento")
                             .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Salvar(Agendamento agendamento)
        {
            try
            {
                using (var Db = _Conexao.AbrirConexao())
                {

                    DynamicParameters Parametros = new DynamicParameters();
                    Parametros.Add("@NOME", agendamento.Nome);
                    Parametros.Add("@DESCRICAO", agendamento.Descricao);
                    Parametros.Add("@HORARIO", agendamento.Horario);
                    Parametros.Add("@CADASTRADOEM", DateTime.Now);
                    Parametros.Add("@ATUALIZADOEM", DateTime.Now);

                    return Db.Query<int>("spSalvarAgendamento", Parametros, commandType: CommandType.StoredProcedure)
                             .FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

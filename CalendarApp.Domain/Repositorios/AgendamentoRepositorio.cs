using CalendarApp.Domain.Interfaces;
using CalendarApp.Infra.Interfaces;
using CalendarApp.Models.Entidades;
using CalendarApp.Models.ValueObjects;
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

        public List<AgendamentoExecucaoComando> Listar(Agendamento agendamento)
        {
            try
            {
                using (var Db = _Conexao.AbrirConexao())
                {
                    var Parametros = new DynamicParameters();

                    if (agendamento.Id > 0)
                        Parametros.Add("@ID", agendamento.Id, DbType.Int32);
                    else
                        Parametros.Add("@ID", DBNull.Value, DbType.Int32);

                    if (!string.IsNullOrEmpty(agendamento.Nome))
                        Parametros.Add("@NOME", agendamento.Nome, DbType.String);
                    else
                        Parametros.Add("@NOME", DBNull.Value, DbType.String);

                    if (!string.IsNullOrEmpty(agendamento.Descricao))
                        Parametros.Add("@DESCRICAO", agendamento.Descricao, DbType.String);
                    else
                        Parametros.Add("@DESCRICAO", DBNull.Value, DbType.String);

                    return Db.Query<AgendamentoExecucaoComando>("spListarAgendamentoExecucaoComando", Parametros, commandType: CommandType.StoredProcedure)
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
                    Parametros.Add("@CADASTRADOEM", agendamento.CadastradoEm);
                    Parametros.Add("@ATUALIZADOEM", agendamento.AtualizadoEm);

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

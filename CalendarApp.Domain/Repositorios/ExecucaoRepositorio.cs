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
    public class ExecucaoRepositorio : IExecucaoRepositorio
    {

        private IConexao _Conexao;

        public ExecucaoRepositorio(IConexao Conexao)
        {
            _Conexao = Conexao;
        }

        public Execucao Alterar(Execucao execucao)
        {
            try
            {
                using (var Db = _Conexao.AbrirConexao())
                {
                    DynamicParameters Parametros = new DynamicParameters();

                    if(execucao.Id > 0)
                        Parametros.Add("@ID", execucao.Id, DbType.Int32);
                    else
                        Parametros.Add("@ID", execucao.Id, DbType.Int32);

                    if (execucao.AgendamentoId > 0)
                        Parametros.Add("@IDAGENDAMENTO", execucao.AgendamentoId, DbType.Int32);
                    else
                        Parametros.Add("@IDAGENDAMENTO", DBNull.Value, DbType.Int32);

                    if(execucao.ComandoId > 0)
                        Parametros.Add("@IDCOMANDO", execucao.ComandoId, DbType.Int32);
                    else
                        Parametros.Add("@IDCOMANDO", DBNull.Value, DbType.Int32);

                    if(execucao.Data < DateTime.MaxValue && execucao.Data > DateTime.MinValue)
                        Parametros.Add("@DATA", execucao.Data, DbType.DateTime);
                    else
                        Parametros.Add("@DATA", DBNull.Value, DbType.DateTime);

                    if(execucao.Executado.HasValue)
                        Parametros.Add("@EXECUTADO", execucao.Executado, DbType.Boolean);
                    else
                        Parametros.Add("@EXECUTADO", DBNull.Value, DbType.Boolean);

                    if (execucao.AtualizadoEm < DateTime.MaxValue && execucao.AtualizadoEm > DateTime.MinValue)
                        Parametros.Add("@ATUALIZADOEM", execucao.AtualizadoEm, DbType.DateTime);
                    else
                        Parametros.Add("@ATUALIZADOEM", DBNull.Value, DbType.DateTime);

                    Db.Query("spAlterarExecucao", Parametros, commandType: CommandType.StoredProcedure);

                    return execucao;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ExecucaoAgendamento> Listar()
        {
            try
            {
                using (var Db = _Conexao.AbrirConexao())
                {
                    return Db.Query<ExecucaoAgendamento>("spListarExecucaoAgendamento", commandType: CommandType.StoredProcedure)
                             .ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Salvar(Execucao execucao)
        {
            try
            {
                using(var Db = _Conexao.AbrirConexao())
                {
                    DynamicParameters Parametros = new DynamicParameters();

                    Parametros.Add("@IDAGENDAMENTO", execucao.AgendamentoId, DbType.Int32);
                    Parametros.Add("@IDCOMANDO", execucao.ComandoId, DbType.Int32);
                    Parametros.Add("@DATA", execucao.Data, DbType.DateTime);
                    Parametros.Add("@HORARIO", execucao.Horario, DbType.DateTime);
                    Parametros.Add("@EXECUTADO", execucao.Executado, DbType.Boolean);
                    Parametros.Add("@CADASTRADOEM", execucao.CadastradoEm, DbType.DateTime);
                    Parametros.Add("@ATUALIZADOEM", execucao.AtualizadoEm, DbType.DateTime);

                    return Db.Query<int>("spSalvarExecucao", Parametros, commandType: CommandType.StoredProcedure)
                            .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}

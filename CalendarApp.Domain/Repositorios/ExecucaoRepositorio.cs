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
            throw new NotImplementedException();
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

                    Parametros.Add("@IDAGENDAMENTO", execucao.AgendamentoId);
                    Parametros.Add("@IDCOMANDO", execucao.ComandoId);
                    Parametros.Add("@DATA", execucao.Data);
                    Parametros.Add("@CADASTRADOEM", execucao.CadastradoEm);
                    Parametros.Add("@ATUALIZADOEM", execucao.AtualizadoEm);

                    return Db.Query<int>("spSalvarExecucao", Parametros, commandType: CommandType.StoredProcedure)
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

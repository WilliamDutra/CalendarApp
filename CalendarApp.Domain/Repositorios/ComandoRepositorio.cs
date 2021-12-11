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
    public class ComandoRepositorio : IComandoRepositorio
    {
        private IConexao _Conexao;

        public ComandoRepositorio(IConexao Conexao)
        {
            _Conexao = Conexao;
        }

        public Comando Alterar(Comando comando)
        {
            throw new NotImplementedException();
        }

        public int Salvar(Comando comando)
        {
            try
            {
                using (var Db = _Conexao.AbrirConexao())
                {
                    DynamicParameters Parametros = new DynamicParameters();

                    Parametros.Add("@NOME", comando.Nome, DbType.String);
                    Parametros.Add("@NOMEARQUIVO", comando.NomeArquivo, DbType.String);
                    Parametros.Add("@DESCRICAO", comando.Descricao, DbType.String);
                    Parametros.Add("@CAMINHO", comando.Caminho, DbType.String);
                    Parametros.Add("@EXECUTAVEL", comando.Executavel, DbType.Boolean);
                    Parametros.Add("@ARGUMENTO", comando.Argumento, DbType.String);
                    Parametros.Add("@CADASTRADOEM", comando.CadastroEm);
                    Parametros.Add("@ATUALIZADOEM", comando.AtualizadoEm);

                    return Db.Query<int>("spSalvarComando", Parametros, commandType: CommandType.StoredProcedure)
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

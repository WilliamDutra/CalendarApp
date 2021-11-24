﻿using CalendarApp.Domain.Interfaces;
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

                    Parametros.Add("@NOME", comando.Nome);
                    Parametros.Add("@DESCRICAO", comando.Descricao);
                    Parametros.Add("@CAMINHO", comando.Caminho);
                    Parametros.Add("@EXECUTAVEL", comando.Executavel);
                    Parametros.Add("@CADASTRADOEM", DateTime.Now);
                    Parametros.Add("@ATUALIZADOEM", DateTime.Now);

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

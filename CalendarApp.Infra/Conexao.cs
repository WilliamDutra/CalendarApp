using CalendarApp.Infra.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CalendarApp.Infra
{
    public class Conexao : IConexao
    {
        private string _ConnectionStrings;

        public Conexao(string ConnectionStrings)
        {
            _ConnectionStrings = ConnectionStrings;
        }

        public SqlConnection AbrirConexao()
        {
            try
            {
                var Db = new SqlConnection(_ConnectionStrings);
                Db.Open();

                return Db;
            }
            catch (Exception)
            {

                throw;
            }
        }
      
    }
}

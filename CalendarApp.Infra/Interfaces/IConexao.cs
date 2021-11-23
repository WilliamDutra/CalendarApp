using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CalendarApp.Infra.Interfaces
{
    public interface IConexao
    {
        SqlConnection AbrirConexao();
    }
}

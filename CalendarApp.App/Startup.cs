using CalendarApp.Domain.Interfaces;
using CalendarApp.Domain.Repositorios;
using CalendarApp.Infra;
using CalendarApp.Infra.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.App
{
    public static class Startup
    {
        public static ServiceProvider Container { get; set; }

        public static void Register(IServiceCollection serviceCollection)
        {
            var service = serviceCollection;

            service.AddScoped<IConexao, Conexao>((Conn) => new Conexao("Server=127.0.0.1,1433; Database=CalendarApp; User Id = sa; Password=yourStrong(!)Password"));
            service.AddScoped<IAgendamentoRepositorio, AgendamentoRepositorio>();
            
            Container = service.BuildServiceProvider();

        }
    }
}

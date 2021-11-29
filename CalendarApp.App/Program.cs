using CalendarApp.App.Interfaces;
using CalendarApp.Domain.Interfaces;
using CalendarApp.Domain.Repositorios;
using CalendarApp.Infra;
using CalendarApp.Infra.Interfaces;
using CalendarApp.Models.Entidades;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CalendarApp.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {

                var serviceCollection = new ServiceCollection();
                Startup.Register(serviceCollection);
                var age = Startup.Container.GetService<IAgendamento>();
                var exe = Startup.Container.GetService<IExecucao>();
                var cmd = Startup.Container.GetService<IComando>();

            }catch(Exception ex)
            {

            }

        }
    }
}

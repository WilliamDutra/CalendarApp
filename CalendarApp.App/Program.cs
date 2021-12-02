using CalendarApp.App.Interfaces;
using CalendarApp.Domain.Interfaces;
using CalendarApp.Domain.Repositorios;
using CalendarApp.Infra;
using CalendarApp.Infra.Interfaces;
using CalendarApp.Models.Entidades;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

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
                //var age = Startup.Container.GetService<IAgendamento>();
                //var exe = Startup.Container.GetService<IExecucao>();
                //var cmd = Startup.Container.GetService<IComando>();
                var prompt = Startup.Container.GetService<IPrompt>();

                prompt.Run(@"C:\Users\willd\Desktop\Tese\contador.bat", ConsoleWrite);


            }catch(Exception ex)
            {

            }

        }

        static void ConsoleWrite(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

    }
}

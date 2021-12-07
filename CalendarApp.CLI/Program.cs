using CalendarApp.App;
using CalendarApp.App.Interfaces;
using CalendarApp.Infra.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CalendarApp.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INICIANDO EXECUÇÕES DE AGENDAMENTOS");

            try
            {

                var serviceCollection = new ServiceCollection();
                Startup.Register(serviceCollection);
                var age = Startup.Container.GetService<IAgendamento>();
                var exec = Startup.Container.GetService<IExecucao>();
                var prompt = Startup.Container.GetService<IPrompt>();

                var agendamentos = age.ListarAgendamentoParaExecucao();

                foreach (var agendamento in agendamentos)
                {
                    try
                    {

                        var args1 = agendamento.Argumento.Split(' ');

                        prompt.Run(agendamento.Caminho, agendamento.Nome, args1, agendamento.Horario);
                        

                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    Console.WriteLine("Passou");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();

        }
    }
}

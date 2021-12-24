using CalendarApp.App;
using CalendarApp.App.Interfaces;
using CalendarApp.Infra.Interfaces;
using CalendarApp.Models.Entidades;
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
                var toast = Startup.Container.GetService<IToast>();

                while (true)
                {

                    var agendamentos = age.ListarAgendamentoParaExecucao();

                    foreach (var agendamento in agendamentos)
                    {
                        try
                        {

                            var args1 = agendamento.Argumento.Split(';');
                                                        
                            bool isExecucao = prompt.Run(agendamento.Caminho, agendamento.NomeArquivo, args1, agendamento.Horario, agendamento.Data);

                            if (isExecucao)
                            {
                                var ex = new Execucao();
                                ex.AtualizadoEm = DateTime.Now;
                                ex.Executado = true;
                                ex.Id = agendamento.ExecucaoId;
                                exec.Alterar(ex);
                                Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}] - AGENDAMENTO {agendamento.Nome.ToUpper()} EXECUTADO COM SUCESSO");
                                toast.ShowMessage("Sucesso", "Agendamento executado com sucesso!");
                                break;
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }

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

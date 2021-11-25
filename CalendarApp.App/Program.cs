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

                var ag = new Agendamento();
                ag.Nome = "Teste";
                ag.Descricao = "Teste";
                ag.Horario = DateTime.Now;
                ag.CadastradoEm = DateTime.Now;
                ag.AtualizadoEm = DateTime.Now;

                var idAg = age.Salvar(ag);

                var comando = new Comando();
                comando.Nome = "Novo Comando";
                comando.Descricao = "Descrição";
                comando.Caminho = "C:\\Users\\willdun";
                comando.Executavel = true;

                var idCmd = cmd.Salvar(comando);


                var ex = new Execucao();
                ex.AgendamentoId = idAg;
                ex.ComandoId = idCmd;
                ex.Data = DateTime.Now;


                exe.Salvar(ex);

            }catch(Exception ex)
            {

            }

        }
    }
}

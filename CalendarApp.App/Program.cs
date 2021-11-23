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
                var age = Startup.Container.GetService<IAgendamentoRepositorio>();
                var ag = new Agendamento();
                ag.Nome = "Teste";
                ag.Descricao = "Teste";
                ag.Horario = DateTime.Now;
                ag.CadastradoEm = DateTime.Now;
                ag.AtualizadoEm = DateTime.Now;

                age.Salvar(ag);

            }catch(Exception ex)
            {

            }

        }
    }
}

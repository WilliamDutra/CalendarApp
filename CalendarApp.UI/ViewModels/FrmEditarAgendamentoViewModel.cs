using CalendarApp.App;
using CalendarApp.App.Interfaces;
using CalendarApp.Models.Entidades;
using Microsoft.Extensions.DependencyInjection;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.UI.ViewModels
{
    public class FrmEditarAgendamentoViewModel : ViewModelBase
    {

        public Command AlterarCommand { get; set; }

        public FrmEditarAgendamentoViewModel(int Id)
        {
            var agendamento = Startup.Container.GetService<IAgendamento>();
            var current = agendamento.Listar(Id);

            Nome = current.Nome;
            Descricao = current.Descricao;
            Horario = current.Horario.ToString("HH:mm");

            AlterarCommand = new Command(() => Alterar(Id));
            
        }

        public FrmEditarAgendamentoViewModel()
        {

        }

        private string _Nome;

        public string Nome
        {
            get
            {
                return _Nome;
            }
            set
            {
                SetProperty(ref _Nome, value);
            }
        }

        private string _Descricao;

        public string Descricao
        {
            get
            {
                return _Descricao;
            }
            set
            {
                SetProperty(ref _Descricao, value);
            }
        }

        private string _Horario;

        public string Horario
        {
            get
            {
                return _Horario;
            }
            set
            {
                SetProperty(ref _Horario, value);
            }
        }

        private void Alterar(int Id)
        {
            var agendamento = Startup.Container.GetService<IAgendamento>();

            var agendamentoEditado = new Agendamento();
            agendamentoEditado.Id = Id;
            agendamentoEditado.Nome = Nome;
            agendamentoEditado.Descricao = Descricao;
            agendamentoEditado.Horario = DateTime.Parse($"{DateTime.Now.ToString("yyyy-MM-dd")} {Horario}");
            agendamentoEditado.AtualizadoEm = DateTime.Now;

            agendamento.Alterar(agendamentoEditado);

        }
    }
}

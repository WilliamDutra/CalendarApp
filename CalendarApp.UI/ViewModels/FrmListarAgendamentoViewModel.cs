using CalendarApp.App.Interfaces;
using CalendarApp.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using MvvmHelpers.Commands;
using CalendarApp.UI.FRM;

namespace CalendarApp.UI.ViewModels
{
    public class FrmListarAgendamentoViewModel : ViewModelBase
    {
        public Command EditarCommand { get; set; }

        public FrmListarAgendamentoViewModel()
        {
            var execucoes = CalendarApp.App.Startup.Container.GetService<IExecucao>();
            ListaAgendamentos = execucoes.ListarExecucoesAgendamento();

            EditarCommand = new Command((Id) => Editar((int)Id));

        }

        private List<ExecucaoAgendamento> _ListaAgendamentos;

        public List<ExecucaoAgendamento> ListaAgendamentos
        {
            get
            {
                return _ListaAgendamentos;
            }
            set
            {
                SetProperty(ref _ListaAgendamentos, value);
            }
        }

        private void Editar(int Id)
        {
            var frmEditarAgendamento = new FrmEditarAgendamento(Id);
            frmEditarAgendamento.ShowDialog();
        }

    }
}

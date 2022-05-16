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

        public Command VerCommand { get; set; }

        public FrmListarAgendamentoViewModel()
        {
            var execucoes = CalendarApp.App.Startup.Container.GetService<IExecucao>();
            ListaAgendamentos = execucoes.ListarExecucoesAgendamento();

            EditarCommand = new Command((Id) => Editar((int)Id));
            VerCommand = new Command((Id) => Ver((int)Id));
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

        private void Ver(int Id)
        {
            var frmListarExecucao = new FrmListarExecucao(Id);
            frmListarExecucao.ShowDialog();
        }

    }
}

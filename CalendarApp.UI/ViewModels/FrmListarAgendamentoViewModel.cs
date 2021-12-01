using CalendarApp.App.Interfaces;
using CalendarApp.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace CalendarApp.UI.ViewModels
{
    public class FrmListarAgendamentoViewModel : ViewModelBase
    {
        
        public FrmListarAgendamentoViewModel()
        {
            var execucoes = CalendarApp.App.Startup.Container.GetService<IExecucao>();
            ListaAgendamentos = execucoes.ListarExecucoesAgendamento();
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
    }
}

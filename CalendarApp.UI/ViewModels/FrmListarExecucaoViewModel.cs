using System;
using System.Text;
using CalendarApp.App;
using CalendarApp.App.Interfaces;
using CalendarApp.Models.ValueObjects;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using CalendarApp.Models.Entidades;

namespace CalendarApp.UI.ViewModels
{
    public class FrmListarExecucaoViewModel : ViewModelBase
    {

        private List<Execucao> _ListaExecucoes;

        public List<Execucao> ListaExecucoes 
        { 
            get 
            { 
                return _ListaExecucoes; 
            }
            set 
            { 
                SetProperty(ref _ListaExecucoes, value); 
            }
        }

        public FrmListarExecucaoViewModel(int Id)
        {
            ListarExecucoesPorAgendamento(Id);
        }

        private void ListarExecucoesPorAgendamento(int IdAgendamento)
        {
            var execucao = Startup.Container.GetService<IExecucao>();
            var execucoes = execucao.Listar(new Execucao() { AgendamentoId = IdAgendamento });
            ListaExecucoes = execucoes;
        }

    }
}

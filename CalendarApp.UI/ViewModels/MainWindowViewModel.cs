using CalendarApp.UI.FRM;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public Command Visualizar { get; set; }

        public Command Cadastrar { get; set; }

        public MainWindowViewModel()
        {
            Cadastrar = new Command(() => new FrmCriarAgendamento().ShowDialog());
            Visualizar = new Command(() => new FrmListarAgendamento().ShowDialog());
        }

    }
}

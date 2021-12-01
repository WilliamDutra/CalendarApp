using CalendarApp.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalendarApp.UI.FRM
{
    /// <summary>
    /// Lógica interna para FrmListarAgendamento.xaml
    /// </summary>
    public partial class FrmListarAgendamento : Window
    {
        public FrmListarAgendamento()
        {
            InitializeComponent();
            DataContext = new FrmListarAgendamentoViewModel();
        }
    }
}

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
    /// Lógica interna para FrmEditarAgendamento.xaml
    /// </summary>
    public partial class FrmEditarAgendamento : Window
    {
        public FrmEditarAgendamento(int Id)
        {
            InitializeComponent();
            DataContext = new FrmEditarAgendamentoViewModel(Id);
        }
    }
}

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
    /// Lógica interna para FrmListarExecucao.xaml
    /// </summary>
    public partial class FrmListarExecucao : Window
    {
        public FrmListarExecucao()
        {
            InitializeComponent();
        }

        public FrmListarExecucao(int Id)
        {
            InitializeComponent();
            DataContext = new FrmListarExecucaoViewModel(Id);
        }
    }
}

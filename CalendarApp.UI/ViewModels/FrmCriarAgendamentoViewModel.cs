using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.UI.ViewModels
{
    public class FrmCriarAgendamentoViewModel : ViewModelBase
    {

        #region Binding Properties

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

        #endregion

    }
}

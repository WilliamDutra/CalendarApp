using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Infra.Interfaces
{
    public interface IToast
    {
        void ShowMessage(string Titulo, string Mensagem);
    }
}

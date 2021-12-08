using CalendarApp.Infra.Interfaces;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Infra.Helpers
{
    public class ToastHelper : IToast
    {
        public void ShowMessage(string Titulo, string Mensagem)
        {
            ToastContentBuilder builder = new ToastContentBuilder();
            builder.AddText(Titulo)
                   .AddText(Mensagem)
                   .Show();
        }
    }
}

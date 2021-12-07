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
            builder.AddArgument("action", "viewConversation")
                   .AddArgument("conversationId", 9813)
                   .AddText("Andrew sent you a picture")
                   .AddText("Check this out, The Enchantments in Washington!")
                   .Show();
        }
    }
}

using CalendarApp.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.App.Interfaces
{
    public interface IComando
    {
        int Salvar(Comando comando);

    }
}

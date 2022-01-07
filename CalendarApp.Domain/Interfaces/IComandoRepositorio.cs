using CalendarApp.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Domain.Interfaces
{
    public interface IComandoRepositorio
    {
        int Salvar(Comando comando);

        Comando Alterar(Comando comando);

        List<Comando> Listar(Comando comando);

    }
}

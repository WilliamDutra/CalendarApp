using CalendarApp.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Domain.Interfaces
{
    public interface IExecucaoRepositorio
    {
        int Salvar(Execucao execucao);

        Execucao Alterar(Execucao execucao);

    }
}

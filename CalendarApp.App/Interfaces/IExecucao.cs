using CalendarApp.Models.Entidades;
using CalendarApp.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.App.Interfaces
{
    public interface IExecucao
    {
        int Salvar(Execucao execucao);

        List<ExecucaoAgendamento> ListarExecucoesAgendamento();

        Execucao Alterar(Execucao execucao);

    }
}

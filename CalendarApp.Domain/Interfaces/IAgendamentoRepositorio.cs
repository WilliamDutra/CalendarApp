using CalendarApp.Models.Entidades;
using CalendarApp.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Domain.Interfaces
{
    public interface IAgendamentoRepositorio
    {
        List<Agendamento> Listar();

        List<AgendamentoExecucaoComando> Listar(Agendamento agendamento);

        int Salvar(Agendamento agendamento);

        Agendamento Alterar(Agendamento agendamento);

        Agendamento Listar(int Id);

    }
}

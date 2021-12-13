using CalendarApp.Models.Entidades;
using CalendarApp.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.App.Interfaces
{
    public interface IAgendamento
    {
        int Salvar(CadastrarAgendamento agendamento);

        List<AgendamentoExecucaoComando> ListarAgendamentoParaExecucao();

        Agendamento Listar(int Id);

        List<Agendamento> Listar(Agendamento agendamento);

        Agendamento Alterar(Agendamento agendamento);

    }
}

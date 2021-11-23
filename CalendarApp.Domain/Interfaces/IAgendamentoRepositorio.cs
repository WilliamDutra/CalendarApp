using CalendarApp.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Domain.Interfaces
{
    public interface IAgendamentoRepositorio
    {
        List<Agendamento> Listar();

        int Salvar(Agendamento agendamento);

        Agendamento Alterar(Agendamento agendamento);

    }
}

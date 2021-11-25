using CalendarApp.App.Interfaces;
using CalendarApp.Domain.Interfaces;
using CalendarApp.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.App.Services
{
    public class AgendamentoService : IAgendamento
    {
        private IAgendamentoRepositorio _AgendamentoRepositorio;

        public AgendamentoService(IAgendamentoRepositorio AgendamentoRepositorio)
        {
            _AgendamentoRepositorio = AgendamentoRepositorio;
        }

        public int Salvar(Agendamento agendamento)
        {
            try
            {
                return _AgendamentoRepositorio.Salvar(agendamento);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

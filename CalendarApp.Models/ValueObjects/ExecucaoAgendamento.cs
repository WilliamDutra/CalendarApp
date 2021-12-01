using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Models.ValueObjects
{
    public class ExecucaoAgendamento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataExecucao { get; set; }

        public DateTime HorarioExecucao { get; set; }

        public DateTime AtualizadoEm { get; set; }

    }
}

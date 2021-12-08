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

        public bool Executado { get; set; }

        public DateTime Data { get; set; }

        public DateTime Horario { get; set; }

        public DateTime AtualizadoEm { get; set; }

    }
}

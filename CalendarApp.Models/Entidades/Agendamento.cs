using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Models.Entidades
{
    public class Agendamento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime Horario { get; set; }

        public DateTime CadastradoEm { get; set; }

        public DateTime AtualizadoEm { get; set; }

    }
}

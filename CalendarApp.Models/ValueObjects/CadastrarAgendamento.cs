using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Models.ValueObjects
{
    public class CadastrarAgendamento
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Horario { get; set; }

        public string NomeComando { get; set; }

        public string Comando { get; set; }

        public bool Executavel { get; set; }

    }
}

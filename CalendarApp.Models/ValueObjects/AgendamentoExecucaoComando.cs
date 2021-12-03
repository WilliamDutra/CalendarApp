using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Models.ValueObjects
{
    public class AgendamentoExecucaoComando
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Comando { get; set; }

        public string Caminho { get; set; }

        public string Argumento { get; set; }

        public DateTime Data { get; set; }

        public DateTime AtualizadoEm { get; set; }

        public string Descricao { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Models.Entidades
{
    public class Execucao
    {
        public int Id { get; set; }

        public int AgendamentoId { get; set; }

        public int ComandoId { get; set; }

        public DateTime Data { get; set; }

        public string MensagemRetorno { get; set; }

        public bool? Executado { get; set; }

        public DateTime CadastradoEm { get; set; }

        public DateTime AtualizadoEm { get; set; }

    }
}

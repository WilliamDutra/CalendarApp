using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Models.Entidades
{
    public class Comando
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Caminho { get; set; }

        public bool Executavel { get; set; }

        public DateTime CadastroEm { get; set; }

        public DateTime AtualizadoEm { get; set; }

    }
}

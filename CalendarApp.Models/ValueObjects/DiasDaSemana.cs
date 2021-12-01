using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Models.ValueObjects
{
    public class DiasDaSemana
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool IsChecked { get; set; }

    }
}

using CalendarApp.App.Interfaces;
using CalendarApp.Domain.Interfaces;
using CalendarApp.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.App.Services
{
    public class ExecucaoService : IExecucao
    {
        private IExecucaoRepositorio _ExecucaoRepositorio;

        public ExecucaoService(IExecucaoRepositorio ExcucaoRepositorio)
        {
            _ExecucaoRepositorio = ExcucaoRepositorio;
        }

        public int Salvar(Execucao execucao)
        {
            try
            {
                return _ExecucaoRepositorio.Salvar(execucao);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

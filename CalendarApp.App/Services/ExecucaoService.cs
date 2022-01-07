using CalendarApp.App.Interfaces;
using CalendarApp.Domain.Interfaces;
using CalendarApp.Models.Entidades;
using CalendarApp.Models.ValueObjects;
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

        public Execucao Alterar(Execucao execucao)
        {
            try
            {
                return _ExecucaoRepositorio.Alterar(execucao);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Execucao> Listar(Execucao execucao)
        {
            try
            {
                return _ExecucaoRepositorio.Listar(execucao);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ExecucaoAgendamento> ListarExecucoesAgendamento()
        {
            try
            {
                return _ExecucaoRepositorio.Listar();
            }
            catch (Exception)
            {

                throw;
            }
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

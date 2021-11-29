using CalendarApp.App.Interfaces;
using CalendarApp.Domain.Interfaces;
using CalendarApp.Models.Entidades;
using CalendarApp.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.App.Services
{
    public class AgendamentoService : IAgendamento
    {
        private IAgendamentoRepositorio _AgendamentoRepositorio;

        private IExecucao _ExecucaoService;

        private IComando _ComandoService;

        public AgendamentoService(IAgendamentoRepositorio AgendamentoRepositorio, IExecucao ExecucaoService, IComando ComandoService)
        {
            _AgendamentoRepositorio = AgendamentoRepositorio;
            _ExecucaoService = ExecucaoService;
            _ComandoService = ComandoService;
        }

        public int Salvar(CadastrarAgendamento agendamento)
        {
            try
            {
                var ag = new Agendamento();
                ag.AtualizadoEm = DateTime.Now;
                ag.CadastradoEm = DateTime.Now;
                ag.Descricao = agendamento.Descricao;
                ag.Horario = DateTime.Parse($"{DateTime.Now.ToString("dd-MM-yyyy")} {agendamento.Horario}");
                ag.Nome = agendamento.Nome;

                var cmd = new Comando();
                cmd.AtualizadoEm = DateTime.Now;
                cmd.CadastroEm = DateTime.Now;
                cmd.Nome = agendamento.NomeComando;
                cmd.Executavel = agendamento.Executavel;
                cmd.Caminho = agendamento.Comando;

                int idAgendamento = _AgendamentoRepositorio.Salvar(ag);
                int idComando = _ComandoService.Salvar(cmd);

                var exec = new Execucao();
                exec.AgendamentoId = idAgendamento;
                exec.ComandoId = idComando;
                exec.CadastradoEm = DateTime.Now;
                exec.AtualizadoEm = DateTime.Now;
                exec.Data = DateTime.Now;

                int idExecucao = _ExecucaoService.Salvar(exec);

                return idAgendamento;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

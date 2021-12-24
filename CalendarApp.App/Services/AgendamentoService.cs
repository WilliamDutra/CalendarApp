using CalendarApp.App.Interfaces;
using CalendarApp.Domain.Constantes;
using CalendarApp.Domain.Interfaces;
using CalendarApp.Models.Entidades;
using CalendarApp.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Agendamento Alterar(Agendamento agendamento)
        {
            try
            {
                return _AgendamentoRepositorio.Alterar(agendamento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Agendamento Listar(int Id)
        {
            try
            {
                return _AgendamentoRepositorio.Listar(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Agendamento> Listar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public List<AgendamentoExecucaoComando> ListarAgendamentoParaExecucao()
        {
            try
            {
                var pesquisa = new Agendamento();
                return _AgendamentoRepositorio.Listar(pesquisa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Salvar(CadastrarAgendamento agendamento)
        {
            try
            {
                int idAgendamento = 0;
                int idComando = 0;
                int idExecucao = 0;

                var De = agendamento.De;
                var Ate = agendamento.Ate;

                // Obtêm o total de dias entre os periodos escolhidos
                int NumeroDeDiasAgendados = DiferencaEntreDatas(De, Ate);

                if(NumeroDeDiasAgendados >= 1)
                {
                    var ag = new Agendamento();
                    ag.AtualizadoEm = DateTime.Now;
                    ag.CadastradoEm = DateTime.Now;
                    ag.Descricao = agendamento.Descricao;
                    ag.Horario = DateTime.Parse($"{DateTime.Now.ToString("dd-MM-yyyy")} {agendamento.Horario}");
                    ag.Nome = agendamento.Nome;
                    idAgendamento = _AgendamentoRepositorio.Salvar(ag);

                    var cmd = new Comando();
                    cmd.AtualizadoEm = DateTime.Now;
                    cmd.CadastroEm = DateTime.Now;
                    cmd.Nome = agendamento.NomeComando;
                    cmd.NomeArquivo = agendamento.NomeArquivo;
                    cmd.Executavel = agendamento.Executavel;
                    cmd.Caminho = agendamento.Caminho;
                    cmd.Argumento = agendamento.Argumento;
                    idComando = _ComandoService.Salvar(cmd);

                    // Percorre a diferença de dias entre o periodo "De" "Ate"
                    for (int i = 0; i < NumeroDeDiasAgendados; i++)
                    {
                        // Data de execução do agendamento
                        var DataExecucao = DateTime.Now.AddDays(i);

                        // Percorre os dias da semana selecionados para o agendamento 
                        for (int k = 0; k < agendamento.DiasDaSemana.Count(); k++)
                        {
                            // Obtêm o dia da semanda da data em execução
                            var DataExecucaoDaSemana = (int)DataExecucao.DayOfWeek;

                            // Verifica se o dia da semana é igual ao dia selecionado no cadastro
                            if (DataExecucaoDaSemana == agendamento.DiasDaSemana[k].Id)
                            {

                                var exec = new Execucao();
                                exec.AgendamentoId = idAgendamento;
                                exec.ComandoId = idComando;
                                exec.Executado = false;
                                exec.Horario = DateTime.Parse($"{DataExecucao} {agendamento.Horario}");
                                exec.CadastradoEm = DateTime.Now;
                                exec.AtualizadoEm = DateTime.Now;
                                exec.Data = DataExecucao;
                                idExecucao = _ExecucaoService.Salvar(exec);

                            }

                        }
                    }
                }
                else
                {
                    var ag = new Agendamento();
                    ag.AtualizadoEm = DateTime.Now;
                    ag.CadastradoEm = DateTime.Now;
                    ag.Descricao = agendamento.Descricao;
                    ag.Horario = DateTime.Parse($"{DateTime.Now.ToString("dd-MM-yyyy")} {agendamento.Horario}");
                    ag.Nome = agendamento.Nome;
                    idAgendamento = _AgendamentoRepositorio.Salvar(ag);

                    var cmd = new Comando();
                    cmd.AtualizadoEm = DateTime.Now;
                    cmd.CadastroEm = DateTime.Now;
                    cmd.Nome = agendamento.NomeComando;
                    cmd.NomeArquivo = agendamento.NomeArquivo;
                    cmd.Argumento = agendamento.Argumento;
                    cmd.Executavel = agendamento.Executavel;
                    cmd.Caminho = agendamento.Caminho;
                    idComando = _ComandoService.Salvar(cmd);

                    var exec = new Execucao();
                    exec.AgendamentoId = idAgendamento;
                    exec.ComandoId = idComando;
                    exec.Executado = false;
                    exec.CadastradoEm = DateTime.Now;
                    exec.AtualizadoEm = DateTime.Now;
                    exec.Data = DateTime.Now;
                    exec.Horario = DateTime.Parse($"{DateTime.Now.ToString("dd-MM-yyyy")} {agendamento.Horario}");
                    idExecucao = _ExecucaoService.Salvar(exec);
                }

                return idAgendamento;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método que retorna o total de dias da diferença passadas por parametro
        /// </summary>
        /// <param name="DataInicio">Data de Inicio</param>
        /// <param name="DataFim">Data de Fim</param>
        /// <returns>Retorna o total de dias da diferença entre datas</returns>
        private int DiferencaEntreDatas(DateTime DataInicio, DateTime DataFim)
        {
            if(DataInicio > DateTime.MinValue && DataFim < DateTime.MaxValue)
                return (int)Math.Abs(DataInicio.Subtract(DataFim).TotalDays);
            return 0;
        }

    }
}

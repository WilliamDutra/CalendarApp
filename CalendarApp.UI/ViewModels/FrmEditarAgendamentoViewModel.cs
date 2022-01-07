using CalendarApp.App;
using CalendarApp.App.Interfaces;
using CalendarApp.Models.Entidades;
using Microsoft.Extensions.DependencyInjection;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarApp.UI.ViewModels
{
    public class FrmEditarAgendamentoViewModel : ViewModelBase
    {

        public Command AlterarCommand { get; set; }

        private Comando _ComandoSelecionado;

        public Comando ComandoSelecionado 
        {
            get
            {
                return _ComandoSelecionado;
            }
            set
            {
                SetProperty(ref _ComandoSelecionado, value);
            }
        }

        private List<Comando> _ListaDeComandos;

        public List<Comando> ListaDeComandos
        {
            get
            {
                return _ListaDeComandos;
            }
            set
            {
                SetProperty(ref _ListaDeComandos, value);
            }
        }

        public FrmEditarAgendamentoViewModel(int Id)
        {
            var agendamento = Startup.Container.GetService<IAgendamento>();
            var current = agendamento.Listar(Id);
            
            Nome = current.Nome;
            Descricao = current.Descricao;
            Horario = current.Horario.ToString("HH:mm");

            AlterarCommand = new Command(() => Alterar(Id));

            CarregarComandoPorAgendamento(Id);
            CarregarComandos();
        }

        public FrmEditarAgendamentoViewModel()
        {

        }

        private string _Nome;

        public string Nome
        {
            get
            {
                return _Nome;
            }
            set
            {
                SetProperty(ref _Nome, value);
            }
        }

        private string _Descricao;

        public string Descricao
        {
            get
            {
                return _Descricao;
            }
            set
            {
                SetProperty(ref _Descricao, value);
            }
        }

        private string _Horario;

        public string Horario
        {
            get
            {
                return _Horario;
            }
            set
            {
                SetProperty(ref _Horario, value);
            }
        }

        private void Alterar(int Id)
        {
            var agendamento = Startup.Container.GetService<IAgendamento>();

            var agendamentoEditado = new Agendamento();
            agendamentoEditado.Id = Id;
            agendamentoEditado.Nome = Nome;
            agendamentoEditado.Descricao = Descricao;
            agendamentoEditado.Horario = DateTime.Parse($"{DateTime.Now.ToString("yyyy-MM-dd")} {Horario}");
            agendamentoEditado.AtualizadoEm = DateTime.Now;

            agendamento.Alterar(agendamentoEditado);

        }

        private void CarregarComandoPorAgendamento(int AgendamentoId)
        {
            var execucao = Startup.Container.GetService<IExecucao>();
            var comando = Startup.Container.GetService<IComando>();

            var pesquisaExecucao = new Execucao();
            pesquisaExecucao.AgendamentoId = AgendamentoId;

            var currentExecucao = execucao.Listar(pesquisaExecucao)
                                          .FirstOrDefault();

            var pesquisaComando = new Comando();
            pesquisaComando.Id = currentExecucao.ComandoId;

            var currentComando = comando.Listar(pesquisaComando)
                                        .FirstOrDefault();

            ComandoSelecionado = currentComando;
        }

        private void CarregarComandos()
        {
            var comando = Startup.Container.GetService<IComando>();
            ListaDeComandos = comando.Listar(new Comando());
        }

    }
}

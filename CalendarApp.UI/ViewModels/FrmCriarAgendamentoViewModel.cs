using CalendarApp.App.Interfaces;
using CalendarApp.UI.Validations;
using MvvmHelpers.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CalendarApp.Models.ValueObjects;
using System.Collections.ObjectModel;

namespace CalendarApp.UI.ViewModels
{
    public class FrmCriarAgendamentoViewModel : ViewModelBase, IDataErrorInfo
    {

        private readonly CadastroAgendamentoValidator _AgendamentoValidator;

        public Command SalvarCommand { get; set; }


        public FrmCriarAgendamentoViewModel()
        {
            _AgendamentoValidator = new CadastroAgendamentoValidator();
            DiasDaSemana = CarregarDias();
            SalvarCommand = new Command(Salvar);
        }


        #region Binding Properties

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

        private string _NomeComando;
        public string NomeComando
        {
            get
            {
                return _NomeComando;
            }
            set
            {
                SetProperty(ref _NomeComando, value);
            }
        }

        private string _Comando;

        public string Comando
        {
            get
            {
                return _Comando;
            }
            set
            {
                SetProperty(ref _Comando, value);
            }
        }

        private string _Argumento;

        public string Argumento 
        {
            get
            {
                return _Argumento;
            }
            set
            {
                SetProperty(ref _Argumento, value);
            }
        }

        private bool _Executavel;

        public bool Executavel
        {
            get
            {
                return _Executavel;
            }
            set
            {
                SetProperty(ref _Executavel, value);
            }
        }

        private DateTime _De;

        public DateTime De
        {
            set
            {
                SetProperty(ref _De, value);
            }
            get
            {
                return _De;
            }
        }

        private DateTime _Ate;

        public DateTime Ate 
        {
            get
            {
                return _Ate;
            }
            set
            {
                SetProperty(ref _Ate, value);
            }
        }

        private ObservableCollection<DiasDaSemana> _DiasDaSemana;

        public ObservableCollection<DiasDaSemana> DiasDaSemana
        {
            set
            {
                SetProperty(ref _DiasDaSemana, value);
            }
            get
            {
                return _DiasDaSemana;
            }
        }


        #endregion

        private void Salvar()
        {

            var DiasSelecionados = DiasDaSemana.Where(x => x.IsChecked == true)
                                               .ToList();

            var agendamento = CalendarApp.App.Startup.Container.GetService<IAgendamento>();
            var novoAgendamento = new CadastrarAgendamento();
            novoAgendamento.Comando = Comando;
            novoAgendamento.Argumento = Argumento;
            novoAgendamento.Executavel = Executavel;
            novoAgendamento.Nome = Nome;
            novoAgendamento.Horario = Horario;
            novoAgendamento.NomeComando = NomeComando;
            novoAgendamento.Descricao = Descricao;
            novoAgendamento.DiasDaSemana = DiasSelecionados;
            novoAgendamento.De = De;
            novoAgendamento.Ate = Ate;

            agendamento.Salvar(novoAgendamento);
        }

        private ObservableCollection<DiasDaSemana> CarregarDias()
        {
            return new ObservableCollection<DiasDaSemana>()
            {
                new DiasDaSemana
                {
                    Id = 0,
                    Nome = "Domingo"
                },
                new DiasDaSemana
                {
                    Id = 1,
                    Nome = "Segunda-Feira"
                },
                new DiasDaSemana
                {
                    Id = 2,
                    Nome = "Terça-Feira"
                },
                new DiasDaSemana
                {
                    Id = 3,
                    Nome = "Quarta-Feira"
                },
                new DiasDaSemana
                {
                    Id = 4,
                    Nome = "Quinta-Feira"
                },
                new DiasDaSemana
                {
                    Id = 5,
                    Nome = "Sexta-Feira"
                },
                new DiasDaSemana
                {
                    Id = 6,
                    Nome = "Sábado"
                },
            };
        }

        public string Error 
        {
            get
            {
                if(_AgendamentoValidator != null)
                {
                    var Resultado = _AgendamentoValidator.Validate(this);

                    if (Resultado != null && Resultado.Errors.Any())
                    {
                        var Errors = string.Join(Environment.NewLine, Resultado.Errors.Select(x => x.ErrorMessage).ToArray());
                        return Errors;
                    }
                }

                return string.Empty;

            }
        }

        public string this[string columnName]
        {
            get
            {
                var Erro = _AgendamentoValidator.Validate(this).Errors.FirstOrDefault(x => x.PropertyName == columnName);
                if (Erro != null)
                    return _AgendamentoValidator != null ? Erro.ErrorMessage : "";

                return string.Empty;
            }
        }



    }
}

﻿using CalendarApp.App.Interfaces;
using CalendarApp.UI.Validations;
using MvvmHelpers.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CalendarApp.Models.ValueObjects;

namespace CalendarApp.UI.ViewModels
{
    public class FrmCriarAgendamentoViewModel : ViewModelBase, IDataErrorInfo
    {

        private readonly CadastroAgendamentoValidator _AgendamentoValidator;

        public Command SalvarCommand { get; set; }


        public FrmCriarAgendamentoViewModel()
        {
            _AgendamentoValidator = new CadastroAgendamentoValidator();
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

        #endregion

        private void Salvar()
        {

            var agendamento = CalendarApp.App.Startup.Container.GetService<IAgendamento>();
            var novoAgendamento = new CadastrarAgendamento();
            novoAgendamento.Comando = Comando;
            novoAgendamento.Executavel = Executavel;
            novoAgendamento.Nome = Nome;
            novoAgendamento.Horario = Horario;
            novoAgendamento.NomeComando = NomeComando;
            novoAgendamento.Descricao = Descricao;

            agendamento.Salvar(novoAgendamento);
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

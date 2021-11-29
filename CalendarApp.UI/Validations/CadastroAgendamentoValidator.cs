using CalendarApp.UI.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.UI.Validations
{
    public class CadastroAgendamentoValidator : AbstractValidator<FrmCriarAgendamentoViewModel>
    {
        public CadastroAgendamentoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório!");
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("O campo Descrição é obrigatório!");
            RuleFor(x => x.Horario)
                .NotEmpty()
                .WithMessage("O campo Horário é obrigatório!");
        }
    }
}

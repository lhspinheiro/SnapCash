using FluentValidation;
using SnapCash.Communication.Request;

namespace SnapCash.Application.Validations;

public class ValidationRegisterRequest : AbstractValidator<RegisterRequest>
{
    
    public ValidationRegisterRequest()
    {
        RuleFor(name => name.NomeCompleto).NotEmpty().WithMessage("Campo Obrigátório");
        RuleFor(cpf => cpf.CPF.Length).GreaterThanOrEqualTo(8).WithMessage("CPF inválido");
        RuleFor(email => email.Email).EmailAddress().WithMessage("E-mail inválido");
        RuleFor(senha => senha.Senha.Length).GreaterThanOrEqualTo(6)
            .WithMessage("A senha deve ser maior que 6 caracteres");
        RuleFor(saldo => saldo.Saldo).GreaterThan(0).WithMessage("O valor deve ser maior que 0");
        RuleFor(type => type.UserType).IsInEnum()
            .WithName("Tipo de usuário inválido! Selecione o tipo comum ou lojista.");
    }
}
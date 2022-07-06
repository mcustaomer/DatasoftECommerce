using DatasoftECommerceApi.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.Validators
{
    public class LoginValidator : AbstractValidator<LoginVm>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Lütfen email alanını boş bırakmayınız!")
                .MinimumLength(10)
                .WithMessage("Email alanı 10 karakterden fazla olmalıdır!")
                .MaximumLength(150)
                .WithMessage("Email alanı 150 karakterden fazla olmalıdır!")
                .EmailAddress()
                .WithMessage("Email adresi yanlış tanımlanmış!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Lütfen parolanızı giriniz!");
        }
    }
}

using DatasoftECommerceApi.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.Validators
{
    public class UserCreateValidator : AbstractValidator<UserCreateVm>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email alanı boş geçilemez!")
                .EmailAddress()
                .WithMessage("Email alanı düzgün formatta değil!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Parola alanı boş geçilemez!");

            RuleFor(x => x.RePassword)
                .NotEmpty()
                .WithMessage("Parola tekrar alanı boş geçilemez");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Kullanıcı ismi alanı boş geçilemez!");
        }
    }
}

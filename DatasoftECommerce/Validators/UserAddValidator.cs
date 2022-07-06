using DatasoftECommerceApi.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.Validators
{
    public class UserAddValidator : AbstractValidator<UserAddVm>
    {
        public UserAddValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email adresi boş geçilemez!")
                .EmailAddress()
                .WithMessage("Email adresi düzgün formatta değil!");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Kullanıcı ismi boş geçilemez!");

            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("Rol ismi boş geçilemez!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Parola alanı boş geçilemez!");

            RuleFor(x => x.RePassword)
                .NotEmpty()
                .WithMessage("Parola tekrar alanı boş geçilemez!");
        }
    }
}

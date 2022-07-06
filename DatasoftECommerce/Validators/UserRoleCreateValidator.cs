using DatasoftECommerceApi.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.Validators
{
    public class UserRoleCreateValidator : AbstractValidator<UserRoleCreateVm>
    {
        public UserRoleCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı boş geçilemez!");
        }
    }
}

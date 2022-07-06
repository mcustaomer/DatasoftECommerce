using DatasoftECommerceApi.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.Validators
{
    public class RoleAssignValidator : AbstractValidator<RoleAssignVm>
    {
        public RoleAssignValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("Rol boş geçilemez!");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("Kullanıcı seçmelisiniz!");
        }
    }
}

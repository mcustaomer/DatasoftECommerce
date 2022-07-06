using DatasoftECommerceApi.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.Validators
{
    public class CategoryCreateValidator : AbstractValidator<CategoryCreateVm>
    {
        public CategoryCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Lütfen bu alanı boş bırakmayınız!")
                .MinimumLength(3)
                .WithMessage("Alan 3 karakterden fazla olmalıdır!")
                .MaximumLength(50)
                .WithMessage("Alan 50 karakterden fazla olmamalıdır!");
        }
    }
}

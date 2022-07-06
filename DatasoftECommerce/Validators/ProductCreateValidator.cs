using DatasoftECommerceApi.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.Validators
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateVm>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı boş geçilemez!");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Fiyat alanı boş geçilemez!");

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Kod alanı boş geçilemez!");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("Kategori seçmelisiniz!");
        }
    }
}

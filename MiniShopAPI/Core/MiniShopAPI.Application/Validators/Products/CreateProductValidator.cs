using System;
using FluentValidation;
using MiniShopAPI.Application.ViewModels.Products;

namespace MiniShopAPI.Application.Validators.Products
{
	public class CreateProductValidator : AbstractValidator<VM_Create_Product>
	{
		public CreateProductValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty()
				.NotNull()
					.WithMessage("Please fill the product name..")
				.MaximumLength(150)
				.MinimumLength(3)
					.WithMessage("Please enter the product name between 5 and 150 characters");

			RuleFor(p => p.Stock)
				.NotNull()
				.NotEmpty()
					.WithMessage("Please fill the stock..")
				.Must(s => s >= 0)
					.WithMessage("Stock information cannot be negative!");

            RuleFor(p => p.Price)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Please fill the price..")
                .Must(s => s >= 0)
                    .WithMessage("Price information cannot be negative!");

        }
	}
}


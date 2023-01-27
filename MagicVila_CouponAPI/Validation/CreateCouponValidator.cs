using FluentValidation;
using MagicVila_CouponAPI.Models.DTO;

namespace MagicVila_CouponAPI.Validation
{
    public class CreateCouponValidator:AbstractValidator<CouponCreatedDTO>
    {
        public CreateCouponValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x => x.Persent).InclusiveBetween(1, 100);
        }
    }
}

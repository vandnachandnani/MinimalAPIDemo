using FluentValidation;
using MagicVila_CouponAPI.Models.DTO;

namespace MagicVila_CouponAPI.Validation
{
    public class UpdateCouponValidator:AbstractValidator<CouponUpdatedDTO>
    {
        public UpdateCouponValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x => x.Persent).InclusiveBetween(1, 100);
        }
    }
}

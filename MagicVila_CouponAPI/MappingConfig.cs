using AutoMapper;
using MagicVila_CouponAPI.Models;
using MagicVila_CouponAPI.Models.DTO;

namespace MagicVila_CouponAPI
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Coupon, CouponCreatedDTO>().ReverseMap();
            CreateMap<Coupon, CouponUpdatedDTO>().ReverseMap();
        }
    }
}

using MagicVila_CouponAPI.Models;
using Microsoft.AspNetCore.Connections;

namespace MagicVila_CouponAPI.Repository.IRepository
{
    public interface ICouponRepository
    {
        Task<ICollection<Coupon>>GetAllAsync();
        Task<Coupon> GetByIdAsync(int id);
        Task CreateAsync(Coupon coupon);
        Task UpdateAsync(Coupon coupon);    
        Task DeleteAsync(Coupon coupon);
        Task Save();
    }
}

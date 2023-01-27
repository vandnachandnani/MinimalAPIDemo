using MagicVila_CouponAPI.Data;
using MagicVila_CouponAPI.Models;
using MagicVila_CouponAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MagicVila_CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _db;

        public CouponRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Coupon coupon)
        {
            _db.Add(coupon);
        }

        public async Task DeleteAsync(Coupon coupon )
        {
            _db.Remove(coupon);
        }

        public async Task<ICollection<Coupon>> GetAllAsync()
        {
          return await _db.Coupons.ToListAsync();
        }

        public async Task<Coupon> GetByIdAsync(int id)
        {
            return _db.Coupons.FirstOrDefault(x=>x.Id== id);
        }

        public async Task Save()
        {
            _db.SaveChanges();
        }

        public async Task UpdateAsync(Coupon coupon)
        {
            _db.Update(coupon);
        }
    }
}

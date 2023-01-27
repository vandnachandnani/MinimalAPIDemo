using MagicVila_CouponAPI.Models;
using MagicVila_CouponAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MagicVila_CouponAPI.Data
{
    public class ApplicationDbContext:DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}

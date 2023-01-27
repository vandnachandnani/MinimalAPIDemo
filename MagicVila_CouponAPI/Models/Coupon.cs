namespace MagicVila_CouponAPI.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Name   { get; set; }
        public int Persent { get; set; }
        public bool IsActive { get; set; }  
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}

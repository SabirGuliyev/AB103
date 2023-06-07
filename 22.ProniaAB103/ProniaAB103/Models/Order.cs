namespace ProniaAB103.Models
{
    public class Order:BaseEntity
    {
        public bool? Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime PurchasedAt { get; set; }
        public List<BasketItem> BasketItems { get; set; }
    }
}

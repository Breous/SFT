using System;


namespace SFT.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int UserID { get; set; }
        public required string Brand { get; set; }
        public required string ItemName { get; set; }
        public required string Material { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; } // 1-5 scale
        public DateTime DateLogged { get; set; }
    }
}

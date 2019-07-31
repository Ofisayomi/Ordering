using System.Collections.Generic;

namespace Order_Manager.Models.Domain
{
    public class Product
    {
        public int ProductId {get; set;}
        public string ImagePath {get; set;}
        public string Description {get; set;}
        public decimal Price { get; set; }
        public List<Order> Orders {get; set;}

    }
}
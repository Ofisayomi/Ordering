using System;

namespace Order_Manager.Models.Domain
{
    public class Order
    {
        public Order (){
            DateCreated = DateTime.Now;
        }
        public int OrderId { get; set;}
        public int Quantity {get; set;}
        public int Price {get; set;}
        public int ProductId {get; set;}
        public Product Product { get; set; }
        public int CartId {get; set;}
        public Cart Cart { get; set; }
        public DateTime DateCreated {get; set;}
    }
}
using System.Collections.Generic;

namespace Order_Manager.Models.Domain
{
    public class Cart
    {
        public int CartId {get; set;}
        public string CustomerName {get; set;}
        public string PhoneNumber {get; set;}
        public string Email {get; set;}
        public bool IsDelivered {get; set;}
        public int OfficeId {get; set;}
        public Office Office {get; set;}
        public List<Order> Orders {get; set;}
    }
}
using System.Collections.Generic;

namespace Order_Manager.Models.Domain
{
    public class Office
    {
        public int OfficeId {get; set;}
        public string Description {get; set;}
        public double longitude { get; set; }
        public double latitude {get; set;}
        public List<Cart> Carts {get; set;}
    }
}
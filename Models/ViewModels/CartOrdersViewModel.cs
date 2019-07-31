using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Order_Manager.Models.ViewModels
{
    public class CartOrdersViewModel
    {
        [Required]
        public double longitude {get; set;}
        [Required]
        public double latitude {get; set;}
        [Required]
        public string customerName {get; set;}
        public string phoneNumber {get; set;}
        [DataType(DataType.EmailAddress)]
        public string email {get; set;}
        public List<OrderViewModel> orders {get; set;}
    }
}
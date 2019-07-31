using System;
using System.ComponentModel.DataAnnotations;

namespace Order_Manager.Models.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public int quantity {get; set;}
        [Required]
        public int price {get; set;}
        [Required]
        public int productId {get; set;}
        
    }
}
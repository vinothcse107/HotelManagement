using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelWCFService.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int TotalQuantity { get; set; }
        public int ItemActive { get; set; }
        public int FoodCategoryId { get; set; }
        public ICollection<Order_Items_Link> Orders { get; set; }

    }
}
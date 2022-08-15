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
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int TotalQuantity { get; set; }
        public bool ItemActive { get; set; }
        public int FoodCategoryId { get; set; }

    }
}
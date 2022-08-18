using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWCFService.DTO
{
    public class OrderListDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }

    public class KitchenOrderDTO
    {

        public int Quantity { get; set; }

        public string ItemName { get; set; }
    }

}
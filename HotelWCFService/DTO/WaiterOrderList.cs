using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWCFService.DTO
{
    public class WaiterOrderList
    {
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

    public class WaiterOrderListGroupBy
    {
        public int OrderId { get; set; }
        public List<string> ItemName { get; set; }
        public List<int> Quantity { get; set; }
        public List<int> Price { get; set; }
    }
}
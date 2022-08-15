using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelWCFService.Models
{
    public class Order_Items_Link
    {
        public int ItemId { get; set; }
        public int OderId{ get; set; }
        public int Quantity{ get; set; }


    }
}
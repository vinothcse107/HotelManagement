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
        [Key , ForeignKey("Items")]
        public int ItemId { get; set; }
        public Items Items { get; set; }
        [Key , ForeignKey("Orders")]
        public int OderId{ get; set; }
        [JsonIgnore]
        public Orders Orders { get; set; }
        public int Quantity{ get; set; }


    }
}
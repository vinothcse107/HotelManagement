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
    public class Table
    {
        [Key]
        public int TableId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [JsonIgnore]
        public Orders Orders { get; set; }
        public ICollection<Orders> TableOrders { get; set; }

    }
}
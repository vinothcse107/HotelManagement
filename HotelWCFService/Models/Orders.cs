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
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Table")]
        public int TableId { get; set; }
        [JsonIgnore]
        public Table Table { get; set; }

        [ForeignKey("user")]
        public int WaiterId { get; set; }
        [JsonIgnore]
        public Users user{ get; set; }
        public ICollection<Table> TableOrders { get; set; }
    }
}
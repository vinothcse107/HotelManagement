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
        public int TableId { get; set; }
        public int OrderId { get; set; }

    }
}
using OnlineTicketApp.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketApp.Models
{
   [Table("Cities")]
   public class City:Entity<int>
    {
        public string Name { get; set; }
    }
}

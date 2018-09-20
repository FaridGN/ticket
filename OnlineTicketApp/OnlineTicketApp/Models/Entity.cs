using OnlineTicketApp.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketApp.Models
{
   public class Entity<T>
    {
        [PrimaryKey]
        public T Id { get; set; }
    }
}

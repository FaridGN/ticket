using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketApp.Core.Annotations
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
   public sealed class TableAttribute : Attribute
    {
        // This is a positional argument
        public TableAttribute(string tableName,string schemeName="dbo")
        {
            this.TableName = tableName;
        }

        public string TableName { get; }

    }
}

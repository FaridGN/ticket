using OnlineTicketApp.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketApp.Core
{
    public abstract class SqlBaseQueryGenerator<T> : ISqlQueryGenerator<T>
    {
        public abstract string GenerateDeleteQuery(T item);

        public abstract string GenerateInsertQuery(T item);

        public abstract string GenerateSelectByIdQuery<K>(K item);

        public abstract string GenerateSelectQuery(Type t);

        public abstract string GenerateUpdateQuery(T item);

        public virtual string GetTableName(object item)
        {
            string tableName = item.GetType().GetCustomAttribute<TableAttribute>().TableName;

            return tableName ?? item.GetType().Name;
        }

        public virtual string GetTableName()
        {
            string tableName = typeof(T).GetCustomAttribute<TableAttribute>().TableName;

            return tableName ?? typeof(T).Name;
        }

    }
}

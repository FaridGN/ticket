using System;
using OnlineTicketApp.Models;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using OnlineTicketApp.Core.Annotations;

namespace OnlineTicketApp.Core
{
    public class SqlQueryGenerator<T> : SqlBaseQueryGenerator<T>
    {

        private bool IsNotMappable(PropertyInfo propertyInfo)
        {
            if (propertyInfo.GetCustomAttribute<PrimaryKeyAttribute>() != null)
                return true;
            else
                return false;
        }
        
        public override string GenerateInsertQuery(T item)
        {

           PropertyInfo[] properties = item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            string queryStart = $"INSERT INTO {GetTableName(item)}(";
            string valueStart = " VALUES(";

            List<string> queryProps = new List<string>();
            List<string> queryValues = new List<string>();
            
            foreach (var property in properties)
            {
                if (IsNotMappable(property))
                    continue;
                queryProps.Add($"{property.Name}");

                if(property.PropertyType == typeof(string))
                queryValues.Add($"'{property.GetValue(item)}'");
                else
                    queryValues.Add($"{property.GetValue(item)}");
            }

            StringBuilder query = new StringBuilder();

            query.Append(queryStart);
            query.Append( String.Join(",", queryProps));
            query.Append(")");

            query.Append(valueStart);
            query.Append( String.Join(",", queryValues));
            query.Append(")");
            

            return query.ToString();
        }

        public override string GenerateDeleteQuery(T item)
        {
            PropertyInfo[] properties = item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            string queryStart = $"DELETE FROM {GetTableName(item)}";

            ///update cities set name=baku where id=1
            List<string> queryProps = new List<string>();

            string primaryKey = null;

            foreach (var property in properties)
            {
                if (IsNotMappable(property))
                {
                    primaryKey = $" WHERE {property.Name} = {property.GetValue(item)}";
                    continue;
                }
               
            }


            StringBuilder query = new StringBuilder();

            query.Append(queryStart);

            query.Append(primaryKey);

            return query.ToString();
        }


        public override string GenerateSelectQuery(Type t)
        {
            PropertyInfo[] properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            List<string> propnames = new List<string>();

            foreach (var propname in properties)
            {
                propnames.Add(propname.Name);
            }
            StringBuilder props = new StringBuilder();

            props.Append(String.Join(",", propnames));

           object instance = Activator.CreateInstance(t);

            string query = $"SELECT {props.ToString()} FROM {GetTableName(instance)}";

            ///update cities set name=baku where id=1
           

            return query.ToString();
        }


        public override string GenerateUpdateQuery(T item)
        {

            PropertyInfo[] properties = item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            string queryStart = $"UPDATE {GetTableName(item)} SET ";

            ///update cities set name=baku where id=1
            List<string> queryProps = new List<string>();

            string primaryKey = null;

            foreach (var property in properties)
            {
                if (IsNotMappable(property))
                {
                    primaryKey = $" WHERE {property.Name} = {property.GetValue(item)}";
                    continue;
                 }
                if (property.PropertyType == typeof(string))
                    queryProps.Add($"{property.Name} = '{property.GetValue(item)}'");
                else
                    queryProps.Add($"{property.Name} = {property.GetValue(item)}");
            }


            StringBuilder query = new StringBuilder();

            query.Append(queryStart);
            query.Append(String.Join(",", queryProps));

            query.Append(primaryKey);

            return query.ToString();
        }


        public override string GenerateSelectByIdQuery<K>(K item)
        {
            
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            string queryStart = $"Select * FROM {GetTableName()}";

            ///update cities set name=baku where id=1
            List<string> queryProps = new List<string>();

            string primaryKey = null;

            foreach (var property in properties)
            {
                if (IsNotMappable(property))
                {
                    primaryKey = $" WHERE {property.Name} = {item}";
                    continue;
                }

            }


            StringBuilder query = new StringBuilder();

            query.Append(queryStart);

            query.Append(primaryKey);

            return query.ToString();
        }
    }
}
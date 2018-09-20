using OnlineTicketApp.Core;
using OnlineTicketApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace OnlineTicketApp.DAL
{
   public class DbSet<T,K> : IDbSet<T, K> where T: Entity<K>
    {
        private SqlConnection _Connection;

        public DbSet(SqlConnection connection)
        {
            _Connection = connection;
        }

        private int Manipulate(string query)
        {
            int result = 0;

            using (SqlCommand command = new SqlCommand(query, _Connection))
            {
                result = command.ExecuteNonQuery();
            }

            return result;
        }




        public int Add(T item)
        {
          return  Manipulate(new SqlQueryGenerator<T>().GenerateInsertQuery(item));
        }


        public int Remove(T item)
        {
            return Manipulate(new SqlQueryGenerator<T>().GenerateDeleteQuery(item));
        }


        public int Update(T item)
        {
            return Manipulate(new SqlQueryGenerator<T>().GenerateUpdateQuery(item));
        }



        public IEnumerable<T> GetAll()
        {
            SqlQueryGenerator<T> queryGenerator = new SqlQueryGenerator<T>();

            string selectQuery = queryGenerator.GenerateSelectQuery(typeof(T));

            using (SqlCommand command = new SqlCommand(selectQuery, _Connection))
            {
                using (SqlDataReader rd = command.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        object obj = Activator.CreateInstance(typeof(T));

                        PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

                        foreach (var property in propertyInfos)
                        {
                            property.SetValue(obj, rd[property.Name]);
                        }
                        yield return obj as T;

                    }
                }
            }
           

        }

        public T Get(K itemKey)
        {
            //default acar sozu ile instance yarat
            //misal: eger T int tipinde olarsa ozaman       :  int item = new int() ,stringdirse  :   string item = new string()  olur
            T item = default(T);

           SqlQueryGenerator<T> queryGenerator = new SqlQueryGenerator<T>();

            string deleteQuery = queryGenerator.GenerateSelectByIdQuery<K>(itemKey);

            using (SqlCommand command = new SqlCommand(deleteQuery, _Connection))
            {
                using (SqlDataReader rd = command.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        object obj = Activator.CreateInstance(typeof(T));

                        PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

                        foreach (var property in propertyInfos)
                        {
                            property.SetValue(obj, rd[property.Name]);
                        }
                        item = obj as T;

                    }
                }
            }
            return item;
           
        }
    }
}

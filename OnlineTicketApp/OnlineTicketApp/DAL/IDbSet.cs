using System.Collections.Generic;
using OnlineTicketApp.Models;

namespace OnlineTicketApp.DAL
{
    public interface IDbSet<T, K> where T : Entity<K>
    {
        int Add(T item);

        T Get(K itemKey);

        IEnumerable<T> GetAll();

        int Remove(T item);

        int Update(T item);
    }
}
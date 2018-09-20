using System;

namespace OnlineTicketApp.Core
{
    public interface ISqlQueryGenerator<T>
    {
        string GenerateDeleteQuery(T item);

        string GenerateInsertQuery(T item);

        string GenerateSelectByIdQuery<K>(K item);

        string GenerateSelectQuery(Type t);

        string GenerateUpdateQuery(T item);

    }
}
using DataAccessLayer.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Persistence
{
    public abstract class Repository<T> where T: IEntity, new()
    {
        protected AdoNetContext Context { get; private set; }

        public Repository(AdoNetContext context)
        {
            Context = context;
        }

        protected IEnumerable<T> ToList(IDbCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                List<T> items = new List<T>();
                while (reader.Read())
                {
                    var item = new T();
                    Map(reader, item);
                    items.Add(item);
                }

                return items;
            }
        }

        protected abstract void Map(IDataRecord record, T item);
    }
}

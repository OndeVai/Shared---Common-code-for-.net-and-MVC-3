#region

using System;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using ronin.Dal;

#endregion

namespace ronin.dal
{
    public abstract class BaseSqlRepository<T, TP> : ICrud<T, TP> where T : class
    {
        protected BaseSqlRepository()
        {
            var connString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            DataContext = new DataContext(connString) { Log = new DebuggerWriter() };
            Table = DataContext.GetTable<T>();
        }

        protected Table<T> Table { get; private set; }
        protected DataContext DataContext { get; private set; }

        protected string ConnectionStringName
        {
            get { return "dataRepository"; }
        }

        protected void SaveItem(T item, int primaryKeyValue)
        {
            SaveItem(item, primaryKeyValue, 0);
        }

        protected void SaveItem(T item, Guid primaryKeyValue)
        {
            SaveItem(item, primaryKeyValue, Guid.Empty);
        }

        protected void SaveItem<TKey, TModel>(TModel item, TKey primaryKeyValue, TKey emptyKeyValue)
            where TModel : class
        {
            var table = DataContext.GetTable<TModel>();
            // If it's a new item, just attach it to the DataContext
            if (primaryKeyValue.Equals(emptyKeyValue))
                table.InsertOnSubmit(item);
            else if (table.GetOriginalEntityState(item) == null)
            {
                // We're updating an existing category, but it's not attached to
                // this data context, so attach it and detect the changes
                table.Attach(item);
                table.Context.Refresh(RefreshMode.KeepCurrentValues, item);
            }
            table.Context.SubmitChanges();
        }

        protected void RemoveItem(T item)
        {
            if (item != null)
            {
                Table.DeleteOnSubmit(item);
                Table.Context.SubmitChanges();
            }
        }

        #region Implementation of ICrud<T,in TP>

        public IQueryable<T> Get()
        {
            return Table;
        }

        public abstract T Get(TP id);
        public abstract void Save(T item);
        public abstract void Remove(TP id);

        #endregion
    }
}
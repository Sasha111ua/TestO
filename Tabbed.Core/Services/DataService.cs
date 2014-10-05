using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace OmnicTabs.Core.Services
{
    class DataService : IDataService
    {
        private readonly ISQLiteConnection _connection;

        public DataService(ISQLiteConnectionFactory factory)
        {
            _connection = factory.Create("one.sql");
            _connection.CreateTable<Location>();   
        }

        public void Insert(Location location)
        {
            _connection.Insert(location);
        }

        public void Update(Location location)
        {
            _connection.Update(location);
        }

        public void Delete(Location location)
        {
            _connection.Delete(location);
        }

        public List<Location> GetLocations()
        {
            return _connection.Table<Location>().ToList();
        }
    }
}

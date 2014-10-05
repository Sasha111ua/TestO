using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OmnicTabs.Core.Services
{
    public interface IDataService
    {
        void Insert(Location location);
        void Update(Location location);
        void Delete(Location location);
        List<Location> GetLocations();
    }
}

using Cirrious.MvvmCross.Plugins.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OmnicTabs.Core.Services
{
   public class Location
    {
       [PrimaryKey, AutoIncrement]
       public int Id { get; set; }
       public string Latitude { get; set; }
       public string Longitude { get; set; }
       public string Name { get; set; }
       public DateTime TimeUpdated { get; set; }

       public override string ToString()
       {
           return string.Format("{0} {1}", Name, TimeUpdated) ;
       }
    }
}

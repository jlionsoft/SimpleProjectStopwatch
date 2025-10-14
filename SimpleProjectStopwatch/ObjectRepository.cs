using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProjectStopwatch
{
    public class ObjectRepository
    {
        public static Data.AccessDatabase Database { get; set; }
        static ObjectRepository()
        {
            var context = new Data.ApplicationDbContext();
            context.Database.EnsureCreated();
            Database = new Data.AccessDatabase(context);
        }
    }
}

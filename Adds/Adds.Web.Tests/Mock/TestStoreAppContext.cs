using Adds.Entities;
using Adds.Web.DataContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adds.Web.Tests.Mock
{
    class TestStoreAppContext : IAddsDb
    {
        public TestStoreAppContext()
        {
            Adds = new TestAddDbSet();
        }

        public DbSet<Add> Adds { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Add item) { }
        public void Dispose() { }
    }
}

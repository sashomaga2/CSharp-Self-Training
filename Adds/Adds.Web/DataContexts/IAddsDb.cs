using Adds.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adds.Web.DataContexts
{
    public interface IAddsDb : IDisposable
    {
        DbSet<Add> Adds { get; }
        int SaveChanges();
        void MarkAsModified(Add item);
    }
}

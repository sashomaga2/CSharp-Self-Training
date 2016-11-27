using Adds.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Adds.Web.DataContexts
{
    public class AddsDb : DbContext, IAddsDb
    {
        public AddsDb() : base("DefaultConnection")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public void MarkAsModified(Add item)
        {
            Entry(item).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("library");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Add> Adds { get; set; }
    }
}
﻿using eManager.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eManager.Web.Infrastructure
{
    public class DepartmentDb : DbContext, IDepartmentDataSource
    {
        public DepartmentDb() : base("DefaultConnection")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        IQueryable<Employee> IDepartmentDataSource.Employees
        {
            get
            {
                return Employees;
            }
        }

        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get
            {
                return Departments;
            }
        }

        void IDepartmentDataSource.Save()
        {
            SaveChanges();
        }

        /* Is it the same ??? */
        //public IQueryable<T> Query<T>() where T : class
        //{
        //    return Set<T>();
        //}
    }
}

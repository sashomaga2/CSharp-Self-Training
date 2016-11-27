using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace food.Models
{
    public interface IFoodDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
    }
    public class FoodDB : DbContext, IFoodDb
    {
        public FoodDB() : base("name=DefaultConnection")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}
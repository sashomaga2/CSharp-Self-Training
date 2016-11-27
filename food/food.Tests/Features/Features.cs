using food.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace food.Tests.Features
{

    [TestClass]
    public class Features
    {
        [TestMethod]
        public void Compute_Results_For_One_Review()
        {
            var data = BuildRestaurantAndReviews(ratings: 4);
            //data.Reviews = new List<RestaurantReview>();
            //data.Reviews.Add(new RestaurantReview() { Rating = 4 });

            var rater = new RestaurantRater(data);
            var result = rater.ComputeResult(new SimpleAlghorithm(), 10);

            Assert.AreEqual(result.Rating, 4);
        }

        [TestMethod]
        public void Rating_Includes_First_N_Reviews()
        {
            var data = BuildRestaurantAndReviews(1, 1, 1, 10, 10, 10);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeResult(new SimpleAlghorithm(), 3);

            Assert.AreEqual(result.Rating, 1);
        }


        [TestMethod]
        public void Compute_Results_For_Two_Reviews()
        {
            var data = BuildRestaurantAndReviews(ratings: new int[] { 4,8 });
            //data.Reviews = new List<RestaurantReview>();
            //data.Reviews.Add(new RestaurantReview() { Rating = 4 });
            //data.Reviews.Add(new RestaurantReview() { Rating = 8 });

            var rater = new RestaurantRater(data);
            var result = rater.ComputeResult(new WeightedRatingAlghorithm(), 10);

            Assert.AreEqual(result.Rating, 5);
        }

        private Restaurant BuildRestaurantAndReviews(params int[] ratings)
        {
            var restaurant = new Restaurant();
            restaurant.Reviews = ratings.Select(r => new RestaurantReview { Rating = r }).ToList();

            return restaurant;
        }
    }
}

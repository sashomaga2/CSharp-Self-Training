using System;
using food.Models;
using System.Linq;

namespace food.Tests.Features
{
    internal class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            this._restaurant = restaurant;
        }

        //public RatingResult ComputeRating(int numberOfReviews)
        //{
        //    //return new RatingResult() { Rating = 4 };
        //    var result = new RatingResult();
        //    result.Rating = (int)_restaurant.Reviews.Average(r => r.Rating);
        //    return result;
        //}

        public RatingResult ComputeResult(IRatingAlgorithm algorithm, int numberOfReviews)
        {
            var fiteredReviews = _restaurant.Reviews.Take(numberOfReviews);

            return algorithm.Compute(fiteredReviews.ToList());
        }
        //public RatingResult ComputeWeightedRate(int numberOfReviews)
        //{
        //    var result = new RatingResult();
        //    var reviews = _restaurant.Reviews.ToArray();
        //    var counter = 0;
        //    var total = 0;

        //    // 1st half / 2nd half
        //    for (int i = 0; i < reviews.Count(); i++)
        //    {
        //        if(i < reviews.Count() / 2)
        //        {
        //            counter += 2;
        //            total += reviews[i].Rating * 2;
        //        }
        //        else
        //        {
        //            counter += 1;
        //            total += reviews[i].Rating;
        //        }
        //    }

        //    result.Rating = total / counter;

        //    return result;
        //}
    }
}
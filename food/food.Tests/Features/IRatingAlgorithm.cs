using food.Models;
using System.Collections.Generic;
using System.Linq;

namespace food.Tests.Features
{
    public interface IRatingAlgorithm
    {
        RatingResult Compute(IList<RestaurantReview> reviews);
    }

    public class SimpleAlghorithm : IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var result = new RatingResult();
            result.Rating = (int)reviews.Average(r => r.Rating);
            return result;
        }
    }

    public class WeightedRatingAlghorithm : IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var result = new RatingResult();
            var counter = 0;
            var total = 0;

            // 1st half / 2nd half
            for (int i = 0; i < reviews.Count(); i++)
            {
                if (i < reviews.Count() / 2)
                {
                    counter += 2;
                    total += reviews[i].Rating * 2;
                }
                else
                {
                    counter += 1;
                    total += reviews[i].Rating;
                }
            }

            result.Rating = total / counter;

            return result;
        }
    }
}
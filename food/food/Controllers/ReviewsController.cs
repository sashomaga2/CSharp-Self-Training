using food.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace food.Controllers
{
    public class ReviewsController : Controller
    {
        //[ChildActionOnly]
        //public ActionResult BestReview()
        //{
        //    var bestReview = from r in _reviews
        //                     orderby r.Rating descending
        //                     select r;

        //    return PartialView("_Review", bestReview.First());
        //}
        // GET: Reviews


        private FoodDB _db = new FoodDB();
        public ActionResult Index([Bind(Prefix ="id")] int restaurantId)
        {
            //var model =
            //    from r in _db.Restaurants
            //    where r.Id == restaurantId
            //    select r;

            var model = _db.Restaurants.Find(restaurantId);
            if(model != null)
            {
                return View(model);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            //TempData["RestaurantId"] = restaurantId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review, int restaurantId)
        {
            if(ModelState.IsValid)
            {
                //review.RestaurantId = restaurantId;
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantReview review) // [Bind(Exclude="Reviewer")]
        {
            if(ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}

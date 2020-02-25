using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();
        // POST method
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid && restaurant != null)
            {
                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        //GET ALL
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> allRestaurants = await _context.Restaurants.ToListAsync();
            return Ok(allRestaurants);
        }
        //GET BY ID
        public async Task<IHttpActionResult> GetByID(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            return NotFound();
        }

        //PUT (update)

        //DELETE BY ID
    }
}

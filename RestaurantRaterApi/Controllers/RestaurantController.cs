using RestaurantRaterApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterApi.Controllers
{
    public class RestaurantController : ApiController
    {
        // CRUD 
        // PGPD

        // Connection to where the data is being stored
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // Create - Post
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if(ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest(ModelState);
        }

        // Read - Get
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        // Get by Id
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if(restaurant != null)
            {
                return Ok(restaurant);
            }
            return NotFound();
        }


        // Update - PUT
        [HttpPut]  
                                                        //asking from url      from the body of request
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri] int id, [FromBody] Restaurant model)
        {
            // Making sure the object is not empty
            if(model == null)
            {
                return BadRequest("restaurant cannot be null");
            }

            //Modelstate is checking that the restaurant we were given "model" is valid
            if (ModelState.IsValid)
            {
                Restaurant restaurant = await _context.Restaurants.FindAsync(id);

                if (restaurant != null)
                {
                    restaurant.Name = model.Name;
                    restaurant.Location = model.Location;

                    // removed since we removed setter
                    //restaurant.Rating = model.Rating;

                    await _context.SaveChangesAsync();

                    return Ok();
                }
                //if was null aka was not found

                return NotFound();
            }
            //What happens if Modelstate is not valid
            //Hey you did something wrong and it has to do with the model state
            return BadRequest(ModelState);
        }

        // Delete
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurantById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if(restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurant);

            await _context.SaveChangesAsync();

            return Ok();
        }
        
    }
}

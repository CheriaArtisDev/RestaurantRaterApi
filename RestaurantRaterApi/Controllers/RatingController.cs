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
    public class RatingController : ApiController
    {
        // CRUD
        // PGPD
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // Create - Post
        [HttpPost]
        public async Task<IHttpActionResult> PostRating(Rating model)
        {
            if(ModelState.IsValid)
            {
                _context.Ratings.Add(model);
                await _context.SaveChangesAsync();

                return Ok("Your rating was added.");
            }
            return BadRequest(ModelState);

            // Another way to write it is.....
            //Checking for if the request was empty
            /*if (model == null)
            {
                return BadRequest("You must enter information");
            }

            //Checking if the modelstate is not valid using the bang operator(!) to switch the bool value
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Ratings.Add(model);
            await _context.SaveChangesAsync();
            return Ok("Your rating was added");
            */
        }

        // Read - Get
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            List<Rating> ratings = await _context.Ratings.ToListAsync();
            return Ok(ratings);
        }

        
    }
}

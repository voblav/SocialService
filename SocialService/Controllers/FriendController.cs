using SocialService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialService.Controllers
{
    public class FriendController : ApiController
    {
        ApplicationContext db = new ApplicationContext();
        // GET api/<controller>
        public IEnumerable<Friend> Get()
        {
            return db.Friends.ToList();
        }

        // GET api/<controller>/5
        public Friend Get(int id)
        {
            return db.Friends.Find(id);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Friend friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Friends.Add(friend);
            db.SaveChanges();
            return Ok(friend);
        }

        public IHttpActionResult Put([FromBody]Friend friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(friend).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(friend);
        }

        public IHttpActionResult Delete(int id)
        {
            Friend friend = db.Friends.Find(id);
            if (friend != null)
            {
                db.Friends.Remove(friend);
                db.SaveChanges();
                return Ok(friend);
            }
            return NotFound();
        }
    }
}
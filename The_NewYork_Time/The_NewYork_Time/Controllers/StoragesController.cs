using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using The_NewYork_Time.Models;

namespace The_NewYork_Time.Controllers
{
    [Authorize]
    public class StoragesController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Storage(Article articleDto)
        {
            var userID = User.Identity.GetUserId();
            TNYTContext context = new TNYTContext();
            if (context.Storages.Any(p => p.UserId == userID && p.ArticleId == articleDto.Id))
            {
                //return BadRequest("The attendance already exist!");
                
                context.Storages.Remove(context.Storages.SingleOrDefault(p => p.UserId == userID && p.ArticleId == articleDto.Id));
                context.SaveChanges();
                return Ok("cancel");
            }
            var storage = new Storage() { ArticleId = articleDto.Id, UserId = User.Identity.GetUserId() };
            context.Storages.Add(storage);
            context.SaveChanges();
            return Ok();
        }
    }
}

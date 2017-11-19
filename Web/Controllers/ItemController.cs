using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        #region Private Properties

        private ItemService Service = new ItemService();

        #endregion

        // GET api/Item
        [HttpGet]
        [ResponseCache(VaryByQueryKeys = new string[] { "term" }, Duration = 30)]
        public IEnumerable<Item> Get(string term)
        {
            return this.Service.Search(term);
        }

        // GET api/Item/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return this.Service.Get(id);
        }

        // POST api/Item
        [HttpPost]
        public void Post(Item item)
        {
            this.Service.Save(item);
        }

        //// PUT api/Item/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]Item value)
        //{
        //}

        // DELETE api/Item/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

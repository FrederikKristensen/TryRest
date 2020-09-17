using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestLibary.model;

namespace LetsTryRestAgain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        // Data
        private static List<Item> _data = new List<Item>()
        {
            new Item(1, "Bil", "Middle", 2),
            new Item(2, "Faxe kondi", "Best of the best", 0),
            new Item(3, "Telefon", "Low", 5)
        };

        // GET: api/Item
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _data;
        }

        // GET: api/Item/5
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public Item Get(int id)
        {
            return _data.Find(p => p.Id == id);
        }

        [HttpGet]
        [Route("Name/{substring}")]
        public IEnumerable<Item> GetFromSubstring(String substring)
        {
            return _data.FindAll(i => i.Name.Contains(substring));
        }

        [HttpGet]
        [Route("Quality/{LMH}")]
        public IEnumerable<Item> GetFromQuality(String LMH)
        {
            return _data.FindAll(u => u.Quality.Contains("Low" || "Middle" || "High"));
        }

        // POST: api/Item
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            _data.Add(value);
        }

        // PUT: api/Item/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // coming
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete]
        //[Route("{id}")]
        //public void Delete(int id)
        //{
        //    Item item = Get(id);
        //    if (item != null)
        //    {
        //        _data.Remove(item);
        //    }
        //}

        
    }
}

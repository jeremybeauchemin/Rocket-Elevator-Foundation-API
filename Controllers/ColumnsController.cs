using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RocketApi.Models;
using Microsoft.EntityFrameworkCore;


namespace RocketApi.Controllers
{
    [Route("api/columns")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly jeremyContext _context;

        public ColumnsController(jeremyContext context)
        {
            _context = context;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<List<Columns>> Get()
        {
            return _context.Columns.ToList();
        }

        // GET api/values/id
        [HttpGet("{id}")]
        public ActionResult<Columns> Get(long id)
        {
            var item = _context.Columns.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            var res = new JObject();
            res["id"] = item.Id;
            res["status"] = item.Status;
            return Content(res.ToString(), "application/json");
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        public IActionResult Update(long id, Columns item)
        {
            var change = _context.Columns.Find(id);
            if (change == null)
            {
                return NotFound();
            }
            //change.IsComplete = item.IsComplete;
            change.Status = item.Status;

            _context.Columns.Update(change);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
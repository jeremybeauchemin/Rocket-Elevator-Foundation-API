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
    [Route("api/elevators")]
    [ApiController]
    public class ElevatorsController : ControllerBase
    {
        private readonly mathieu_appContext _context;

        public ElevatorsController(mathieu_appContext context)
        {
            _context = context;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<List<Elevators>> Get()
        {
            return _context.Elevators.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Elevators> Get(long id)
        {
            var item = _context.Elevators.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            var res = new JObject();
            res["id"] = item.Id;
            res["status"] = item.Status;
            return Content(res.ToString(), "application/json");
        }

        [HttpGet("status")]
        public ActionResult<List<Elevators>> Get(string status)
        {
            var item = _context.Elevators.Where(s => s.Status != "Active");
            if (item == null)
            {
                return NotFound();
            }
            var res = new JObject();
            // res["id"] = item.Id;
            // res["status"] = item.Status;
            return item.ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        public IActionResult Update(long id, Elevators item)
        {
            var change = _context.Elevators.Find(id);
            if (change == null)
            {
                return NotFound();
            }
            //change.IsComplete = item.IsComplete;
            change.Status = item.Status;

            _context.Elevators.Update(change);
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
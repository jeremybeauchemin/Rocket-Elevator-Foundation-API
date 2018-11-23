using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RocketApi.Models;
using Microsoft.EntityFrameworkCore;

 
namespace RocketApi.Controllers{

    [Route("api/Interventions")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly jeremyContext _context;

        public InterventionsController(jeremyContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Interventions>> Get()
        {
            return _context.Interventions.Where(s => s.Start == null && s.Status == "pending").ToList();
            }

        // [HttpGet("Status")]
        //     public ActionResult<Interventions> Get(long Status){
        // {
        //     var item = _context.Interventions.Find(Status);
        //     if (item == null)
        //     {
        //         return NotFound();
        //     }
        // }
        //     }

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
    }


}

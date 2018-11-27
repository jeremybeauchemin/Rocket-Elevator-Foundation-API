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
        public ActionResult<List<Interventions>> Get( long Status)
        {
            return _context.Interventions.Where(s => s.Start == null && s.Status == "pending").ToList();
            }
        [HttpPut("{id}", Name = "PutInterventionsStatus")]
        //public void Put(int id, [FromBody] string value)
        public string Update(long id, [FromBody] JObject body)
        {
            var interventions = _context.Interventions.Find(id);
            if (interventions == null)
            {
                return "Return a valid Id";
            }
            var previous_status = interventions.Status;
            var status = (string)body.SelectToken("status");
            if (status == "inProgess")
            {
                DateTime time = DateTime.Now;
                interventions.Status = status;
                interventions.Start = DateTime.Now;
                interventions.Updated_At = DateTime.Now;
                _context.Interventions.Update(interventions);
                _context.SaveChanges();
                return "Interventions #" + interventions.Id + "Has now changed status from " + previous_status + "to" + status +".";
            }
            {
              if (status == "complete")
            {
                DateTime time = DateTime.Now;
                interventions.Status = status;
                interventions.End = DateTime.Now;
                interventions.Updated_At = DateTime.Now;
                _context.Interventions.Update(interventions);
                _context.SaveChanges();
                return "Interventions #" + interventions.Id + " Has now changed status from " + previous_status + " to " + status + ".";  
            }
            else
            {
                return "Invalid Status";
            }
            }
         }
    }   
}


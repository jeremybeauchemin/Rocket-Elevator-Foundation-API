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
            return _context.Interventions.ToList();
            }

        [HttpGet("Status")]
        public ActionResult<List<Interventions>> Get(string Status)
        {
            var item = _context.Interventions.Where(s => s.Status == Status && s.Start == null );
            if (item == null)
            {
                return NotFound();
            }
            var res = new JObject();
            // res["id"] = item.Id;
            // res["status"] = item.status;
            return item.ToList();
        }
    }



}

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
    [Route("api/leads")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly jeremyContext _context;

        public LeadsController(jeremyContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Leads>> Get()
        {
            return _context.Leads.ToList();
        }

        // GET api/values/5
        [HttpGet("id")]
        public ActionResult<Leads> Get(long id)
        {
            var item = _context.Leads.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            var res = new JObject();
            res["id"] = item.Id;
            //res["status"] = item.Status;
            return Content(res.ToString(), "application/json");
        }

        // GET api/values/new
        [HttpGet("new")]
        public ActionResult<List<Leads>> GetByNew()
        {
            DateTime newDate = DateTime.Now.AddDays(-30);
            var item = _context.Leads.Where(update => update.UpdatedAt > newDate && update.CustomerId == null);
            if (item == null)
            {
                return NotFound();
            }
            return item.ToList();
        }
    }
}
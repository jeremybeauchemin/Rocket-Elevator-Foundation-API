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


        [HttpGet("pending")]
        public ActionResult<List<Interventions>> Get(string pending)
        {
            var item = _context.Interventions.Where(s => s.pending != "Active");
            if (item == null)
            {
                return NotFound();
            }
            var res = new JObject();
            // res["id"] = item.Id;
            // res["pending"] = item.pending;
            return item.ToList();
        }



}

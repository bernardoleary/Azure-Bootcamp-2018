using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DockerDemo.Api.Models;

namespace DockerDemo.Api.Controllers
{
    [Route("api/[controller]")]
    public class DatabaseController : Controller
    {
        private readonly ApiContext _context;

        public DatabaseController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _context.Inventory.ToList();
            return Ok(new { Inventory = model });
        }

        [HttpPost]
        public IActionResult Create([FromBody]Inventory model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _context.Inventory.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Inventory model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var inventory = _context.Inventory.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }
            inventory.name = model.name;
            inventory.quantity = model.quantity;
            _context.SaveChanges();
            return Ok(inventory);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var inventory = _context.Inventory.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }
            _context.Remove(inventory);
            _context.SaveChanges();
            return Ok(inventory);
        }
    }
}
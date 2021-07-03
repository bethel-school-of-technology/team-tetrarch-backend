using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCrunch;
using BitCrunch.Models;

namespace BitCrunch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return StatusCode(418);
            }

            return item;
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsbyName(string name)
        {
            List<Item> items = new List<Item>();

            items = await _context.Items.Where(item => item.ItemName.Contains(name)).ToListAsync();
            bool isEmpty = !items.Any();
            if (isEmpty)
            {
                return StatusCode(418);
            }
            return items;
        }

        [HttpGet("store/{name}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItembyStoreName(string name)
        {
            List<Item> items = new List<Item>();

            items = await _context.Items.Where(item => item.StoreName.Contains(name)).ToListAsync();
            bool isEmpty = !items.Any();
            if (isEmpty)
            {
                return StatusCode(418);
            }
            return items;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemID)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemID }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCrunch;
using BitCrunch.Models;
using BitCrunch.Services;
using System.Net;
using System.Web.Http;

namespace BitCrunch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(user);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (ModelState.IsValid)
            {
            
                //here is the password validation
                user.Password = ManualAuth.Sha256(user.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUser", new { id = user.UserId }, user);
            }
            else
            {
                Console.WriteLine("Not Working");
            }
            return user;
        }

        [HttpPost("userName")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                User GetUser = await _context.Users.SingleOrDefaultAsync(u => u.UserName == user.UserName);
                if (GetUser != null)
                {
                    if (ManualAuth.SHA256Check(user.Password, GetUser.Password))
                    {
                        return Ok(GetUser);
                    }
                }

            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}

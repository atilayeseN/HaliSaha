#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HaliSahaApi.Context;
using HaliSahaApi.Models;

namespace HaliSahaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly MainContext _context;

        public PostsController(MainContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Posts>>> GetPostItems()
        {
            return await _context.PostItems.ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Posts>> GetPosts(int id)
        {
            var posts = await _context.PostItems.FindAsync(id);

            if (posts == null)
            {
                return NotFound();
            }

            return posts;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosts(int id, Posts posts)
        {
            if (id != posts.Id)
            {
                return BadRequest();
            }

            _context.Entry(posts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostsExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Posts>> PostPosts(Posts posts)
        {
            _context.PostItems.Add(posts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosts", new { id = posts.Id }, posts);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosts(int id)
        {
            var posts = await _context.PostItems.FindAsync(id);
            if (posts == null)
            {
                return NotFound();
            }

            _context.PostItems.Remove(posts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostsExists(int id)
        {
            return _context.PostItems.Any(e => e.Id == id);
        }
    }
}

#nullable disable
using HaliSahaApi.Context;
using HaliSahaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaliSahaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostManageController : ControllerBase
    {
        private readonly MainContext _context;
        public PostManageController(MainContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Posts>>> GetPosts(Members owner)
        {
            List<Posts> posts = await _context.PostItems.Where(p => p.Owner == owner).ToListAsync();
            if (posts == null)
            {
                return NotFound();
            }



            return posts;
        }
        [HttpPost]
        public async Task<ActionResult<Posts>> AddPost(Posts post)
        {
            if (post == null)
            {
                return BadRequest();
            }
            _context.PostItems.Add(post);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutPosts(Posts post)
        {
            if (post == null)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.PostItems.Any(e => e != post))
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

    }
}

#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HaliSahaApi.Models;
using HaliSahaApi.Context;

namespace HaliSahaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly MainContext _context;

        public MembersController(MainContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Members>>> GetMemberItems()
        {
            return await _context.MemberItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Members>> GetMembers(long id)
        {
            var members = await _context.MemberItems.FindAsync(id);

            if (members == null)
            {
                return NotFound();
            }

            return members;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembers(long id, Members members)
        {
            if (id != members.ID)
            {
                return BadRequest();
            }

            _context.Entry(members).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Members>> PostMembers(Members members)
        {
            var result =_context.MemberItems.Where(e => e.UserName == members.UserName).Any();
            if (result)
            {
               return BadRequest("Başarısız");
            }
            members.BirthDate = members.BirthDate.ToUniversalTime();
            _context.MemberItems.Add(members);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMembers", new { id = members.ID }, members);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembers(long id)
        {
            var members = await _context.MemberItems.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }

            _context.MemberItems.Remove(members);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MembersExists(Members member)
        {
            return _context.MemberItems.Any(e => e.ID == member.ID);
        }

       

    }
}

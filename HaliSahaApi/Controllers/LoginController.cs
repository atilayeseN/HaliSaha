using HaliSahaApi.Models;
using HaliSahaApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HaliSahaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MainContext _context;
        public LoginController (MainContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Members> LoginMembers(Members member)
        {
            var result = _context.MemberItems.FirstOrDefault(e => e.UserName == member.UserName && e.Password == member.Password
            );
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpGet("logout")]
        public OkResult Logout()
        {

            return Ok();
        }
  
    }
}

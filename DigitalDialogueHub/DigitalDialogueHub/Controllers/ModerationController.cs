using DigitalDialogueHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DigitalDialogueHub.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Moderator")] // Ograniči pristup samo za Moderatore
    public class ModerationController : ControllerBase
    {
        private readonly DigitalDialogueHubContext _context;

        public ModerationController(DigitalDialogueHubContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ReportContent([FromBody] Report dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Reports.Add(dto);
            await _context.SaveChangesAsync();

            return Ok("Content reported.");
        }

        [HttpPost]
        public async Task<IActionResult> FlagComment([FromQuery] int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null) return NotFound();

            comment.IsFlagged = true;
            await _context.SaveChangesAsync();

            return Ok("Comment flagged.");
        }

        [HttpPost]
        public async Task<IActionResult> FlagDiscussion([FromQuery] int discussionId)
        {
            var discussion = await _context.Discussions.FindAsync(discussionId);
            if (discussion == null) return NotFound();

            discussion.IsFlagged = true;
            await _context.SaveChangesAsync();

            return Ok("Discussion flagged.");
        }

        [HttpPost]
        public async Task<IActionResult> PromoteToModerator([FromQuery] int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return NotFound();

            user.Role = "Moderator";
            await _context.SaveChangesAsync();

            return Ok("User promoted to Moderator.");
        }

        [HttpPost]
        public async Task<IActionResult> DemoteToStudent([FromQuery] int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return NotFound();

            user.Role = "Student";
            await _context.SaveChangesAsync();

            return Ok("User demoted to Student.");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment([FromQuery] int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null) return NotFound();

            comment.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok("Comment soft deleted.");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDiscussion([FromQuery] int discussionId)
        {
            var discussion = await _context.Discussions.FindAsync(discussionId);
            if (discussion == null) return NotFound();

            discussion.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok("Discussion soft deleted.");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReaction([FromQuery] int reactionId)
        {
            var reaction = await _context.Reactions.FindAsync(reactionId);
            if (reaction == null) return NotFound();

            _context.Reactions.Remove(reaction);
            await _context.SaveChangesAsync();

            return Ok("Reaction deleted.");
        }

        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            var reports = await _context.Reports
                .Include(r => r.Reporter)
                .Include(r => r.CommentId)
                .Include(r => r.Discussion)
                .ToListAsync();

            return Ok(reports);
        }
    }
}

using DigitalDialogueHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace DigitalDialogueHub.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReportsController : ControllerBase
    {
        private readonly DigitalDialogueHubContext _context;

        public ReportsController(DigitalDialogueHubContext context)
        {
            _context = context;
        }

        // GET: api/Reports/GetAll
        [HttpGet]
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> GetAll()
        {
            var reports = await _context.Reports
                .Include(r => r.Reporter)
                .ToListAsync();

            return Ok(reports);
        }

        // POST: api/Reports/Create
        [HttpPost]
        [Authorize(Roles = "Student,Moderator")]
        public async Task<IActionResult> Create([FromBody] Report report)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            report.ReportedAt = DateTime.UtcNow;
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return Ok(report);
        }

        // DELETE: api/Reports/Delete/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> Delete(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
                return NotFound();

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

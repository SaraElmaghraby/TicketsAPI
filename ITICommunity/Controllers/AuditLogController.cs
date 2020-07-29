using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITICommunity.Models;

namespace ITICommunity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly TicketsDilenyContext _context;

        public AuditLogController(TicketsDilenyContext context)
        {
            _context = context;
        }

        // GET: api/AuditLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditLog>>> GetAuditLog()
        {
            return await _context.AuditLog.ToListAsync();
        }

        // GET: api/AuditLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuditLog>> GetAuditLog(int id)
        {
            var auditLog = await _context.AuditLog.FindAsync(id);

            if (auditLog == null)
            {
                return NotFound();
            }

            return auditLog;
        }

        // PUT: api/AuditLog/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditLog(int id, AuditLog auditLog)
        {
            if (id != auditLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(auditLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditLogExists(id))
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

        // POST: api/AuditLog
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AuditLog>> PostAuditLog(AuditLog auditLog)
        {
            _context.AuditLog.Add(auditLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditLog", new { id = auditLog.Id }, auditLog);
        }

        // DELETE: api/AuditLog/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuditLog>> DeleteAuditLog(int id)
        {
            var auditLog = await _context.AuditLog.FindAsync(id);
            if (auditLog == null)
            {
                return NotFound();
            }

            _context.AuditLog.Remove(auditLog);
            await _context.SaveChangesAsync();

            return auditLog;
        }

        private bool AuditLogExists(int id)
        {
            return _context.AuditLog.Any(e => e.Id == id);
        }
    }
}

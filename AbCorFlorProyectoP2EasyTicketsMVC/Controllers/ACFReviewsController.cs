using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbCorFlorProyectoP2EasyTicketsMVC.Data;
using ProyectoEasyTicket.Models;

namespace AbCorFlorProyectoP2EasyTicketsMVC.Controllers
{
    public class ACFReviewsController : Controller
    {
        private readonly AbCorFlorProyectoP2EasyTicketsMVCContext _context;

        public ACFReviewsController(AbCorFlorProyectoP2EasyTicketsMVCContext context)
        {
            _context = context;
        }

        // GET: ACFReviews
        public async Task<IActionResult> ACFIndex()
        {
            var abCorFlorProyectoP2EasyTicketsMVCContext = _context.ACFReviews.Include(a => a.ACFTicket);
            return View(await abCorFlorProyectoP2EasyTicketsMVCContext.ToListAsync());
        }

        // GET: ACFReviews/Details/5
        public async Task<IActionResult> ACFDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCFReviews = await _context.ACFReviews
                .Include(a => a.ACFTicket)
                .FirstOrDefaultAsync(m => m.ACFReviewID == id);
            if (aCFReviews == null)
            {
                return NotFound();
            }

            return View(aCFReviews);
        }

        // GET: ACFReviews/Create
        public IActionResult ACFCreate()
        {
            ViewData["ACFTicketID"] = new SelectList(_context.Set<ACFTicket>(), "ACFTicketID", "ACFEvento");
            return View();
        }

        // POST: ACFReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ACFCreate([Bind("ACFReviewID,ACFComentario,ACFCalificacion,ACFFecha,ACFTicketID")] ACFReviews aCFReviews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCFReviews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ACFIndex));
            }
            ViewData["ACFTicketID"] = new SelectList(_context.Set<ACFTicket>(), "ACFTicketID", "ACFEvento", aCFReviews.ACFTicketID);
            return View(aCFReviews);
        }

        // GET: ACFReviews/Edit/5
        public async Task<IActionResult> ACFEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCFReviews = await _context.ACFReviews.FindAsync(id);
            if (aCFReviews == null)
            {
                return NotFound();
            }
            ViewData["ACFTicketID"] = new SelectList(_context.Set<ACFTicket>(), "ACFTicketID", "ACFEvento", aCFReviews.ACFTicketID);
            return View(aCFReviews);
        }

        // POST: ACFReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ACFEdit(int id, [Bind("ACFReviewID,ACFComentario,ACFCalificacion,ACFFecha,ACFTicketID")] ACFReviews aCFReviews)
        {
            if (id != aCFReviews.ACFReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCFReviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACFReviewsExists(aCFReviews.ACFReviewID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ACFIndex));
            }
            ViewData["ACFTicketID"] = new SelectList(_context.Set<ACFTicket>(), "ACFTicketID", "ACFEvento", aCFReviews.ACFTicketID);
            return View(aCFReviews);
        }

        // GET: ACFReviews/Delete/5
        public async Task<IActionResult> ACFDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCFReviews = await _context.ACFReviews
                .Include(a => a.ACFTicket)
                .FirstOrDefaultAsync(m => m.ACFReviewID == id);
            if (aCFReviews == null)
            {
                return NotFound();
            }

            return View(aCFReviews);
        }

        // POST: ACFReviews/Delete/5
        [HttpPost, ActionName("ACFDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCFReviews = await _context.ACFReviews.FindAsync(id);
            if (aCFReviews != null)
            {
                _context.ACFReviews.Remove(aCFReviews);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ACFIndex));
        }

        private bool ACFReviewsExists(int id)
        {
            return _context.ACFReviews.Any(e => e.ACFReviewID == id);
        }
    }
}

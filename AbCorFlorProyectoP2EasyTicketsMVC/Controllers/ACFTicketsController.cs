using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbCorFlorProyectoP2EasyTicketsMVC.Data;
using ProyectoEasyTicket.Models;
using System.Diagnostics;

namespace AbCorFlorProyectoP2EasyTicketsMVC.Controllers
{
    public class ACFTicketsController : Controller
    {
        private readonly AbCorFlorProyectoP2EasyTicketsMVCContext _context;

        public ACFTicketsController(AbCorFlorProyectoP2EasyTicketsMVCContext context)
        {
            _context = context;
        }

        // GET: ACFTickets
        public async Task<IActionResult> ACFIndex()
        {
            return View(await _context.ACFTicket.ToListAsync());
        }

        // GET: ACFTickets/Details/5
        public async Task<IActionResult> ACFDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCFTicket = await _context.ACFTicket
                .FirstOrDefaultAsync(m => m.ACFTicketID == id);
            if (aCFTicket == null)
            {
                return NotFound();
            }

            return View(aCFTicket);
        }

        // GET: ACFTickets/Create
        public IActionResult ACFCreate()
        {
            return View();
        }

        // POST: ACFTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ACFCreate([Bind("ACFTicketID,ACFEvento,ACFFecha,ACFLugar,ACFButacaSeccion,ACFPrecio,ACFTelefono,ACFVendido,ACFContrasenia")] ACFTicket aCFTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCFTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ACFIndex));
            }
            return View(aCFTicket);
        }

        // GET: ACFTickets/Edit/5
        public async Task<IActionResult> ACFEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCFTicket = await _context.ACFTicket.FindAsync(id);
            if (aCFTicket == null)
            {
                return NotFound();
            }
            return View(aCFTicket);
        }

        // POST: ACFTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ACFEdit(int id, [Bind("ACFTicketID,ACFEvento,ACFFecha,ACFLugar,ACFButacaSeccion,ACFPrecio,ACFTelefono,ACFVendido,ACFContrasenia")] ACFTicket aCFTicket)
        {
            if (id != aCFTicket.ACFTicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCFTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACFTicketExists(aCFTicket.ACFTicketID))
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
            return View(aCFTicket);
        }

        // GET: ACFTickets/Delete/5
        public async Task<IActionResult> ACFDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCFTicket = await _context.ACFTicket
                .FirstOrDefaultAsync(m => m.ACFTicketID == id);
            if (aCFTicket == null)
            {
                return NotFound();
            }

            return View(aCFTicket);
        }

        // POST: ACFTickets/Delete/5
        [HttpPost, ActionName("ACFDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ACFDeleteConfirmed(int id)
        {
            var aCFTicket = await _context.ACFTicket.FindAsync(id);
            if (aCFTicket != null)
            {
                _context.ACFTicket.Remove(aCFTicket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ACFIndex));
        }

        private bool ACFTicketExists(int id)
        {
            return _context.ACFTicket.Any(e => e.ACFTicketID == id);
        }

        public async Task<IActionResult> ACFConfirmarClave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.ACFTicket
                .FirstOrDefaultAsync(m => m.ACFTicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
        // POST: Confirmar Clave
        [HttpPost]
        public async Task<IActionResult> ACFConfirmarClave(int id, string clave)
        {
            var ticket = _context.ACFTicket.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            // Verifica la clave del ticket
            if (ticket.ACFContrasenia == clave)
            {

                var ticketParaEditar = await _context.ACFTicket.FindAsync(id);
                return View("ACFEdit", ticketParaEditar);

            }

            // Clave incorrecta, muestra error
            ModelState.AddModelError("", "La clave ingresada es incorrecta. Por favor, intente nuevamente.");
            return View(ticket);
        }
        public async Task<IActionResult> ACFConfirmarClave2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.ACFTicket
                .FirstOrDefaultAsync(m => m.ACFTicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }


        // POST: Confirmar Clave
        [HttpPost]
        public async Task<IActionResult> ACFConfirmarClave2(int id, string clave)
        {
            var ticket = await _context.ACFTicket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            // Verifica la clave del ticket
            if (ticket.ACFContrasenia == clave)
            {
                TempData["ClaveValidada"] = true;
                return RedirectToAction("ACFDelete", new { id });

            }

            // Clave incorrecta, muestra error
            ModelState.AddModelError("", "La clave ingresada es incorrecta. Por favor, intente nuevamente.");
            return View(ticket);
        }
        public async Task<IActionResult> ACFComprar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.ACFTicket
                .FirstOrDefaultAsync(m => m.ACFTicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [HttpPost]
        public IActionResult ACFComprar(int ticketID)
        {
            Debug.WriteLine("El botón de comprar fue presionado.");

            var ticket = _context.ACFTicket.Find(ticketID);

            if (ticket == null)
            {
                return NotFound();
            }
            ticket.ACFVendido = true;


            _context.Update(ticket);
            _context.SaveChanges();



            TempData["SuccessMessage"] = "¡Venta exitosa! Gracias por su compra.";

            return RedirectToAction("ConfirmacionVenta");


        }

        public IActionResult ConfirmacionVenta()
        {
            return View();
        }
    }
}

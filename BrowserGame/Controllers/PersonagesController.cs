using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrowserGame.Data;
using BrowserGame.Models;

namespace BrowserGame.Controllers
{
    public class PersonagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Personages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personages.ToListAsync());
        }

        // GET: Personages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personage = await _context.Personages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personage == null)
            {
                return NotFound();
            }

            return View(personage);
        }

        // GET: Personages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,History,Possession,Category,Capital")] Personage personage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personage);
        }

        // GET: Personages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personage = await _context.Personages.FindAsync(id);
            if (personage == null)
            {
                return NotFound();
            }
            return View(personage);
        }

        // POST: Personages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,History,Possession,Category,Capital")] Personage personage)
        {
            if (id != personage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonageExists(personage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personage);
        }

        // GET: Personages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personage = await _context.Personages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personage == null)
            {
                return NotFound();
            }

            return View(personage);
        }

        // POST: Personages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personage = await _context.Personages.FindAsync(id);
            _context.Personages.Remove(personage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonageExists(int id)
        {
            return _context.Personages.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using veritabaniCRUD2.Data;
using veritabaniCRUD2.Models;

namespace veritabaniCRUD2.Controllers
{
    public class birTabloVerileriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public birTabloVerileriController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: birTabloVerileri
        public async Task<IActionResult> Index()
        {
              return _context.birTablo != null ? 
                          View(await _context.birTablo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.birTablo'  is null.");
        }

        // GET: birTabloVerileri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.birTablo == null)
            {
                return NotFound();
            }

            var birTablo = await _context.birTablo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (birTablo == null)
            {
                return NotFound();
            }

            return View(birTablo);
        }

        // GET: birTabloVerileri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: birTabloVerileri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,isim,ucret")] birTablo birTablo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(birTablo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(birTablo);
        }

        // GET: birTabloVerileri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.birTablo == null)
            {
                return NotFound();
            }

            var birTablo = await _context.birTablo.FindAsync(id);
            if (birTablo == null)
            {
                return NotFound();
            }
            return View(birTablo);
        }

        // POST: birTabloVerileri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,isim,ucret")] birTablo birTablo)
        {
            if (id != birTablo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(birTablo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!birTabloExists(birTablo.Id))
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
            return View(birTablo);
        }

        // GET: birTabloVerileri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.birTablo == null)
            {
                return NotFound();
            }

            var birTablo = await _context.birTablo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (birTablo == null)
            {
                return NotFound();
            }

            return View(birTablo);
        }

        // POST: birTabloVerileri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.birTablo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.birTablo'  is null.");
            }
            var birTablo = await _context.birTablo.FindAsync(id);
            if (birTablo != null)
            {
                _context.birTablo.Remove(birTablo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool birTabloExists(int id)
        {
          return (_context.birTablo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

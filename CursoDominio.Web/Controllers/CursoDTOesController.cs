using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoXunit.Dominio.Cursos;
using Dominio.DB.Context;

namespace CursoDominio.Web.Controllers
{
    public class CursoDTOesController : Controller
    {
        private readonly AppDbContext _context;

        public CursoDTOesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CursoDTOes
        public async Task<IActionResult> Index()
        {
              return _context.Cursos != null ? 
                          View(await _context.Cursos.ToListAsync()) :
                          Create();
        }

        // GET: CursoDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var cursoDTO = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoDTO == null)
            {
                return NotFound();
            }

            return View(cursoDTO);
        }

        // GET: CursoDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CursoDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Workload,PublicTarget,Value")] CursoDTO cursoDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoDTO);
        }

        // GET: CursoDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var cursoDTO = await _context.Cursos.FindAsync(id);
            if (cursoDTO == null)
            {
                return NotFound();
            }
            return View(cursoDTO);
        }

        // POST: CursoDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Workload,PublicTarget,Value")] CursoDTO cursoDTO)
        {
            if (id != cursoDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoDTOExists(cursoDTO.Id))
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
            return View(cursoDTO);
        }

        // GET: CursoDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var cursoDTO = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoDTO == null)
            {
                return NotFound();
            }

            return View(cursoDTO);
        }

        // POST: CursoDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cursos == null)
            {
                return Problem("Entity set 'AppDbContext.Cursos'  is null.");
            }
            var cursoDTO = await _context.Cursos.FindAsync(id);
            if (cursoDTO != null)
            {
                _context.Cursos.Remove(cursoDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoDTOExists(int id)
        {
          return (_context.Cursos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

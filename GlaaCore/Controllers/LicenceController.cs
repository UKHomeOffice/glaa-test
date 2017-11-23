using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlaaCore.Domain;
using System.Threading.Tasks;
using GlaaCore.Domain.Models;

namespace GlaaCore.Web.Controllers
{
    public class LicenceController : Controller
    {
        private readonly GlaaContext _context;

        public LicenceController(GlaaContext context)
        {
            _context = context;
        }

        // GET: Licence
        public async Task<IActionResult> Index()
        {
            return View(await _context.Licences.ToListAsync());
        }

        // GET: Licence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licence = await _context.Licences.SingleOrDefaultAsync(m => m.Id == id);

            if (licence == null)
            {
                return NotFound();
            }

            return View(licence);
        }

        // GET: Licence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Licence/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationId,OrganisationName")] Licence licence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(licence);
        }

        // GET: Licence/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licence = await _context.Licences.SingleOrDefaultAsync(m => m.Id == id);

            if (licence == null)
            {
                return NotFound();
            }

            return View(licence);
        }

        // POST: Licence/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationId,OrganisationName")] Licence licence)
        {
            if (id != licence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenceExists(licence.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(licence);
        }

        // GET: Licence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licence = await _context.Licences.SingleOrDefaultAsync(m => m.Id == id);

            if (licence == null)
            {
                return NotFound();
            }
            return View(licence);
        }

        // POST: Licence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licence = await _context.Licences.SingleOrDefaultAsync(m => m.Id == id);
            _context.Licences.Remove(licence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenceExists(int id)
        {
            return _context.Licences.Any(e => e.Id == id);
        }
    }
}
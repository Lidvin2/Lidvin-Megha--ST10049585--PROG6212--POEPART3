using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG6212_POEPART3.Data;
using PROG6212_POEPART3.Models;

namespace PROG6212_POEPART3.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturerController(ApplicationDbContext context)
        {
            _context = context;
        }
        // This is lecturercontroller with I can create the buttons like Edit and Delete plus I try all logic to understand what I need to do in my project.
        [Authorize(Roles = "LecturerUser")]
        public async Task<IActionResult> Index()
        {
            var lectures = await _context.Lecturers.ToListAsync();
            return View(lectures);
        }

        [Authorize(Roles = "LecturerUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "LecturerUser")]
        [HttpPost]
        public async Task<IActionResult> Create(Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lecturer);
        }

        [Authorize(Roles = "LecturerUser")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            _context.Lecturers.Remove(lecturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "LecturerUser")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return NotFound();
            }
            return View(lecturer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Lecturer lecturer)
        {
            if (id != lecturer.LecturerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(lecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecturer);
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealRecorder.Data;
using MealRecorder.Models;

namespace MealRecorder.Pages.Meals
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meal Meal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meal = await _context.Meals.FirstOrDefaultAsync(m => m.MealId == id);

            if (Meal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meal = await _context.Meals.FindAsync(id);

            if (Meal != null)
            {
                _context.Meals.Remove(Meal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealRecorder.Data;
using MealRecorder.Models;

namespace MealRecorder.Pages.Meals
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
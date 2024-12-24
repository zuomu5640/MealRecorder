using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MealRecorder.Data;
using MealRecorder.Models;

namespace MealRecorder.Pages.Meals
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Meal Meal { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Meal.CreatedAt = System.DateTime.Now; // í«â¡: çÏê¨ì˙éûÇê›íË
            _context.Meals.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
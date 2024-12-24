using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealRecorder.Data;
using MealRecorder.Models;
using Microsoft.Extensions.Configuration;


namespace MealRecorder.Pages.Meals
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration Configuration; // IConfiguration ��ǉ�

        // IConfiguration ���R���X�g���N�^�Ŏ󂯎��
        public IndexModel(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration; // IConfiguration ��ݒ�
        }
        public IList<Meal> Meal { get; set; }

        public async Task OnGetAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); // Configuration �� IConfiguration �̃C���X�^���X
            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                Meal = await context.Meals.OrderByDescending(m => m.MealDate).ToListAsync();
            }
        }
    }
}
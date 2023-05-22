using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;

namespace ProniaAB103.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);


            return View(await Task.FromResult(settings));
        }
    }
}

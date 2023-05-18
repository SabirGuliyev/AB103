using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;
using ProniaAB103.Models;

namespace ProniaAB103.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Client> clients = await _context.Clients.Include(c=>c.Profession).ToListAsync();

            return View(clients);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Professions=await _context.Professions.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (client.ProfessionId==0)
            {
                ModelState.AddModelError("ProfessionId", "Zehmet olmasa Profession secin");
                ViewBag.Professions = await _context.Professions.ToListAsync();
                return View();
            }
            
            bool result = await _context.Professions.AnyAsync(p => p.Id == client.ProfessionId);
            if (!result)
            {

                ModelState.AddModelError("ProfessionId", "Bu id-li ixtisas yoxdu");
                ViewBag.Professions = await _context.Professions.ToListAsync();
                return View();
            }

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));   
            
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Client existed = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            if (existed == null) return NotFound();
            ViewBag.Professions = await _context.Professions.ToListAsync();

            return View(existed);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,Client client)
        {
            if (id == null || id < 1) return BadRequest();

            Client existed = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            if (existed == null) return NotFound();

            bool result = await _context.Professions.AnyAsync(p => p.Id == client.ProfessionId);
            if (!result)
            {

                ModelState.AddModelError("ProfessionId", "Bu id-li ixtisas yoxdu");
                ViewBag.Professions = await _context.Professions.ToListAsync();
                return View(existed);
            }

            existed.Name = client.Name;
            existed.Surname = client.Surname;
            existed.Message = client.Message;
            existed.ProfessionId=client.ProfessionId;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); 

        }
    }
}

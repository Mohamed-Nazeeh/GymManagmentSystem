using GymManagmentSystem.DAL.Repositries.Classes;
using GymManagmentSystem.DAL.Repositries.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Project_MVC01.Controllers
{
    public class PlanController: Controller
    {
        private readonly IPLanRepository _pLanRepository;

        // Still Wrong
        // private readonly IPLanRepository _pLanRepository = new MockRepository();

        public PlanController(IPLanRepository pLanRepository)
        {
            _pLanRepository = pLanRepository;
        }
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var Plans = await _pLanRepository.GetAllAsync(ct: ct);
            return View(Plans);
        }
        public async Task<IActionResult> Details(int id , CancellationToken ct)
        {
            var plan = await _pLanRepository.GetByIdAsync(id, ct);
            if(plan is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
    }
}

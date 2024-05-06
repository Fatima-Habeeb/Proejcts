using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webproject.Models;

namespace webproject.Controllers
{
    
    public class TeamsController : Controller
    {
        private readonly TeamContext _context;

        public TeamsController(TeamContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LahoreQalandars()
        {
            List<LahoreQalandars> lq = _context.LahoreQalandars.ToList();
            return View(lq);
        }

        public IActionResult KarachiKings()
        {
            List<KarachiKings> kk = _context.KarachiKings.ToList();
            return View(kk);
        }

        public IActionResult IslamabadUnited()
        {
            List<IslamabadUnited> iu = _context.IslamabadUnited.ToList();
            return View(iu);
        }

        public IActionResult MultanSultans()
        {
            List<MultanSultans> ms = _context.MultanSultans.ToList();
            return View(ms);
        }

        public IActionResult PeshawarZalmi()
        {
            List<PeshawarZalmi> pz = _context.PeshawarZalmi.ToList();
            return View(pz);
        }

        public IActionResult QuettaGladiators()
        {
            List<QuettaGladiators> qg = _context.QuettaGladiators.ToList();
            return View(qg);
        }

    }
}

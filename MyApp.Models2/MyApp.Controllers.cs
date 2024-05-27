using MyApp.Models;
using MyApp.Services;

namespace MyApp.Controllers
{
    public class InfoController : Controller
    {
        private readonly IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        public IActionResult Index()
        {
            var infos = _infoService.GetAll();
            return View(infos);
        }

        private IActionResult View(List<Info> infos)
        {
            throw new NotImplementedException();
        }

        public IActionResult Create()
        {
            ViewBag.Professions = _infoService.GetProfessions();
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create(Info info)
        {
            if (ModelState.IsValid)
            {
                var profession = GetProfession(info);
                info.Profession = (Models2.Profession)profession;
                _infoService.Add(info);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Professions = _infoService.GetProfessions();
            return View(info);
        }

        private IActionResult View(Info info)
        {
            throw new NotImplementedException();
        }

        private object GetProfession(Info info)
        {
            return _infoService.GetProfessions().FirstOrDefault(p => p.Id == info.Profession.Id);
        }

        private IActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit(int id)
        {
            var info = _infoService.GetById(id);
            if (info == null)
            {
                return NotFound();
            }
            ViewBag.Professions = _infoService.GetProfessions();
            return View(info);
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Edit(Info info)
        {
            if (ModelState.IsValid)
            {
                var profession = _infoService.GetProfessions().FirstOrDefault(p => p.Id == info.Profession.Id);
                info.Profession = profession;
                _infoService.Update(info);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Professions = _infoService.GetProfessions();
            return View(info);
        }

        public IActionResult Delete(int id)
        {
            var info = _infoService.GetById(id);
            if (info == null)
            {
                return NotFound();
            }
            _infoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

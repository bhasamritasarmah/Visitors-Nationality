using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisitorsNationality.Models;
using VisitorsNationality.Services;

namespace VisitorsNationality.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly IVisitorsService _visitorsService;
        // GET: VisitorsController
        public VisitorsController(IVisitorsService service)
        {
            _visitorsService = service;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Visitor visitor)
        {
            _visitorsService.Create(visitor);
            return RedirectToAction("Index");
        }

        public ActionResult Privacy()
        {
            return View(_visitorsService.Get());
        }

        [HttpPost]
        public ActionResult Privacy(string id)
        {
            return View(nameof(Details), id);
        }

        public ActionResult Details(string id)
        {
            return View(_visitorsService.Get(id));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PeopleManager.Cyb.Ui.Mvc.Models;
using System.Diagnostics;
using PeopleManager.Services;

namespace PeopleManager.Cyb.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonService _personService;

        public HomeController(PersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            var people = _personService.Find();
            return View(people);
        }

        public IActionResult Details(int id)
        {
            var person = _personService.Get(id);
            if (person is null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
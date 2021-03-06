using DependencyInjection_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DependencyInjection_Demo.Infrastructure;
using DependencyInjection_Demo.ViewModels;

namespace DependencyInjection_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepo _repo;
        public HomeController(ILogger<HomeController> logger, IStudentRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            var model = _repo.GetAll();
            return View(model);
        }
        [Route("Home/Details/{id?}")]
        public IActionResult Details(int? id)
        {
            
            var item = _repo.GetById(id??1);
            return View(item);
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
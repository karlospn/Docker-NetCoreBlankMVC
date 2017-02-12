using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using docker.net.core.test.Repository;
using Microsoft.AspNetCore.Mvc;

namespace docker.net.core.test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDockerCommandsRepository _commandsRepository;

        public HomeController(IDockerCommandsRepository commandsRepository)
        {
            _commandsRepository = commandsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var commands = await _commandsRepository.GetDockerCommandsAsync();
            return View(commands);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

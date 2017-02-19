using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using docker.net.core.test.Models;
using docker.net.core.test.Repository;
using docker.net.core.test.Repository.Mongo;
using docker.net.core.test.Repository.Postgres;
using Microsoft.AspNetCore.Mvc;

namespace docker.net.core.test.Controllers
{
    public class HomeController : Controller
    {
        private IPostgresDockerCommandsRepository PostgresDockerCommandsRepository { get; }
        private IMongoDockerCommandsRepository MongoDockerCommandsRepository { get; }


        public HomeController(IPostgresDockerCommandsRepository postgresDockerCommandsRepository, IMongoDockerCommandsRepository mongoDockerCommandsRepository)
        {
            PostgresDockerCommandsRepository = postgresDockerCommandsRepository;
            MongoDockerCommandsRepository = mongoDockerCommandsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var repo = Environment.GetEnvironmentVariable("Database");
            List<DockerCommand> commands;

            if (repo == "1")
            {
               commands = await PostgresDockerCommandsRepository.GetDockerCommandsAsync();
            }
            else
            {
                commands = await MongoDockerCommandsRepository.GetDockerCommandsAsync();
            }
            return View(commands);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["Debug"] = Environment.GetEnvironmentVariable("Database");

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

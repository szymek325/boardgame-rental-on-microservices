using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Base.RabbitMq.Messages;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using Web.Mvc.Models;

namespace Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusClient _client;

        public HomeController(IBusClient client)
        {
            _client = client;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await _client.PublishAsync(new SendEvent("Test Message"));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

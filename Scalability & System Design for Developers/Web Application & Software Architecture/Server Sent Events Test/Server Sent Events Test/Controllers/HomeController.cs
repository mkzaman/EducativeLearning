using Microsoft.AspNetCore.Mvc;
using Server_Sent_Events_Test.Models;
using System.Diagnostics;

namespace Server_Sent_Events_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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

        public void Message()
        {
            Response.ContentType = "text/event-stream";

            DateTime startDate = DateTime.Now;
            while (startDate.AddMinutes(1) > DateTime.Now)
            {
                Response.WriteAsync(string.Format("data: {0}\n\n", DateTime.Now.ToString()));
                //Response.Flush();

                System.Threading.Thread.Sleep(1000);
            }

            Response.Clear();
        }
    }
}
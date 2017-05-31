using System.Collections.Generic;
using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        private ILogger<HomeController> logger;

        public HomeController(UptimeService up, ILogger<HomeController> log){
            uptime = up;
            logger = log;
        }

        public ViewResult Index(bool throwException = false) {
            
            if (throwException){
                throw new System.NullReferenceException();
            }

            logger.LogDebug($"Handled {Request.Path} at uptime {uptime.Uptine}");

            return View(new Dictionary<string, string> {
                ["Message"] = "This is the index action",
                ["Uptime"] = $"{uptime.Uptine}ms"
            });
        }

        public ViewResult Error(){
            return View("Index", new Dictionary<string, string> {
                ["Message"] = "This is the Error action"
            });
        }
    }
}
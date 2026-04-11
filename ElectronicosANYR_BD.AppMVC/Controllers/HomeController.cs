using System.Diagnostics;

using ElectronicosANYR_BD.AppMVC.Models;

using Microsoft.AspNetCore.Mvc;



namespace ElectronicosANYR_BD.AppMVC.Controllers

{

    public class HomeController : Controller

    {

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

    }

}
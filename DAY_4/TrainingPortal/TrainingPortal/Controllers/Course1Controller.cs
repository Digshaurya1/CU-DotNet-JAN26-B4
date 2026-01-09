using Microsoft.AspNetCore.Mvc;

namespace TrainingPortal.Controllers
{
    public class Course1Controller : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Courses()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }

    }
}



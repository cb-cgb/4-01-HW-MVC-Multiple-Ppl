using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _4_01_HW_MVC_Multiple_Ppl.Models;
using _4_01Multiple_Ppl;

namespace _4_01_HW_MVC_Multiple_Ppl.Controllers
{
    public class HomeController : Controller
    {
      public IActionResult Index()
        {
            return View();
        }

          }
}

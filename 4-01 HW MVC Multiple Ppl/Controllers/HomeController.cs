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
        private String _conn = @"Data Source=.\sqlexpress;Initial Catalog=PeopleDB;Integrated Security=True;";

         public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPersonForm(List<Person> ppl)
        {            
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(List<Person> ppl)
        {
            PersonManager pm = new PersonManager(_conn);
            foreach(Person p in ppl )
            {
                pm.AddPerson(p);
            }
            return Redirect("/Home/Index");
        }
    }
}

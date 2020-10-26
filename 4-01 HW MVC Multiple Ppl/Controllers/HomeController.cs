using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _4_01_HW_MVC_Multiple_Ppl.Models;
using _4_01Multiple_Ppl;
using Microsoft.AspNetCore.Http;


namespace _4_01_HW_MVC_Multiple_Ppl.Controllers
{
    public class HomeController : Controller
    {   
        private String _conn = @"Data Source=.\sqlexpress;Initial Catalog=PeopleDB;Integrated Security=True;";

         public IActionResult Index()
        {
            PersonManager pm = new PersonManager(_conn);
            HomeViewModel vm = new HomeViewModel();
            vm.People = pm.GetPeople();
            if (TempData["confirmation"] != null)
            {
                vm.Message = (String)TempData["confirmation"];
            }
            return View(vm);
        }

        public IActionResult AddPersonForm(List<Person> ppl)
        {            
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(List<Person> ppl)
        {
            PersonManager pm = new PersonManager(_conn);
            var pplToAdd = ppl.Where(p => !String.IsNullOrEmpty(p.First) && !String.IsNullOrEmpty(p.Last));
           
            foreach (Person p in pplToAdd)
            {
                pm.AddPerson(p);
            }
            TempData["confirmation"] = "People added successfully!";
                        
            return Redirect("/Home/Index");
        }
    }
}

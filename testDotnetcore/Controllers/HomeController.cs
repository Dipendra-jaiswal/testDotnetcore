using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace testDotnetcore.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index()
        {
            var person = new 
            {
                Name = "dddddd",
                DateTime = DateTime.Now.ToString()
            };
            return Json(person);

        //    return JsonResult({ "Id" = 1,"Name" ="ddddd"});
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XUnitStudyProject.Models;

namespace XUnitStudyProject.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewData["Message"] = "Добрый день, это тестовый текст на главной странице";
            return View("Main", new IndexViewModel {Page=1,Rows=new List<string> {"he","he"},PageTitle="Hello" });
        }

        public IActionResult Privacy()
        {
            ViewData["Policy"] = "Текст политики конфидециальности сайта.";
            return View("Privacy");
        }

        public IActionResult TestPage(int page)
        {
            ViewBag.PageIncrement = ++page;
            return View(new TestPageViewModel{Page = page});
        }

        
    }
}
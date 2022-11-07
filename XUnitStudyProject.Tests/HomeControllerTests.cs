
using Microsoft.AspNetCore.Mvc;
using Xunit;
using XUnitStudyProject.Controllers;
using XUnitStudyProject.Models;

namespace XUnitStudyProject.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);
            Assert.Equal("Main", result.ViewName);
            Assert.Equal(typeof(IndexViewModel), result.Model.GetType());
            Assert.NotNull(result.Model);
            //через ф12 посмотрел возвращает стаус код 200 
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Добрый день, это тестовый текст на главной странице", result?.ViewData["Message"]);
        }
        
        [Fact]
        public void PrivacyTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Privacy() as ViewResult;
            Assert.Contains("Текст политики конфидециальности", (string)result?.ViewData["Policy"]);
            Assert.Equal("Privacy", result?.ViewName);
            Assert.True(result?.Model is null);
            Assert.EndsWith("сайта.", result?.ViewData["Policy"] as string);
            Assert.Equal(39, (result?.ViewData["Policy"] as string).Length);
        }
       [Fact]
        public void TestPageTest()
        {
            HomeController controller = new HomeController();
            int a = 1;
            ViewResult result = controller.TestPage(a) as ViewResult;
            Assert.Equal(++a, controller.ViewBag.PageIncrement);
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.False(result.Model is null);
        }


    }
}
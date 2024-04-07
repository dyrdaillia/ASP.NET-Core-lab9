using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication9.Models;
using System.Threading.Tasks;


namespace WebApplication9.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherComponent _weatherComponent;

        public HomeController()
        {
            _weatherComponent = new WeatherComponent("380672abf85517abb665471a858e0582");
        }

        public IActionResult Index()
        {
            
            var products = new List<Product>
        {
            new Product { ID = 1, Name = "Xiaomi Redmi Note 4", Price = 7000 },
            new Product { ID = 2, Name = "Iphone 15 Pro", Price = 40000 },
            new Product { ID = 3, Name = "Nokia 3310", Price = 500 }
        };

            
            var productsTableComponent = new ProductsTableComponent(products);
            
            string productsTableHtml = productsTableComponent.Render();

            
            var city = "Kyiv";
            var weatherTask = _weatherComponent.GetCurrentWeather(city);
            
            weatherTask.Wait();
            string weatherInfo = weatherTask.Result;

          
            ViewBag.ProductsTableHtml = productsTableHtml;
            ViewBag.WeatherInfo = weatherInfo;

            return View();
        }
    }
}

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
            // Створіть колекцію продуктів для передачі в компонент подання
            var products = new List<Product>
        {
            new Product { ID = 1, Name = "Xiaomi Redmi Note 4", Price = 7000 },
            new Product { ID = 2, Name = "Iphone 15 Pro", Price = 40000 },
            new Product { ID = 3, Name = "Nokia 3310", Price = 500 }
        };

            // Створіть екземпляр компонента подання продуктів і передайте йому колекцію продуктів
            var productsTableComponent = new ProductsTableComponent(products);
            // Отримайте рядок HTML з таблицею продуктів
            string productsTableHtml = productsTableComponent.Render();

            // Отримайте поточну погоду для певного міста (наприклад, Київ)
            var city = "Kyiv";
            var weatherTask = _weatherComponent.GetCurrentWeather(city);
            // Чекаємо на завершення асинхронної операції отримання погоди
            weatherTask.Wait();
            string weatherInfo = weatherTask.Result;

            // Передайте дані в представлення та відобразіть його
            ViewBag.ProductsTableHtml = productsTableHtml;
            ViewBag.WeatherInfo = weatherInfo;

            return View();
        }
    }
}

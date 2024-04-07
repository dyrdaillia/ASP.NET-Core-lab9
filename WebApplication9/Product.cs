using System.Collections.Generic;

namespace WebApplication9
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductsTableComponent
    {
        private List<Product> _products;

        public ProductsTableComponent(List<Product> products)
        {
            _products = products;
        }

        public string Render()
        {
            string table = "<table><tr><th>ID</th><th>Name</th><th>Price</th></tr>";

            foreach (var product in _products)
            {
                table += $"<tr><td>{product.ID}</td><td>{product.Name}</td><td>{product.Price}</td></tr>";
            }

            table += "</table>";

            return table;
        }
    }
}

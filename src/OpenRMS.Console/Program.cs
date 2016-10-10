using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace OpenRMS.Console
{
    public class Program
    {
        public class ProductModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public static void Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                // Output info on the products
                OutputProductInfo(httpClient);

                // Delete products if they exist
                System.Console.WriteLine("Deleting existing products.");
                foreach (ProductModel product in GetProducts(httpClient))
                {
                    var deleteResponse = httpClient.DeleteAsync("http://localhost:49269/productmanagement/products/" + product.Id).Result;
                    System.Console.WriteLine(string.Format("Deleted Product Id: {0}", product.Id));
                }
                System.Console.WriteLine();

                // Create some products
                System.Console.WriteLine("Creating some new products");
                for (int i = 0; i < 3; i++)
                {
                    var productId = CreateProduct(httpClient, i + 1);
                    System.Console.WriteLine(string.Format("Created Product Id: {0}", productId));
                }
                System.Console.WriteLine();

                // Output info on the products
                OutputProductInfo(httpClient);

                // Updating products
                System.Console.WriteLine("Updating products");
                foreach (ProductModel product in GetProducts(httpClient))
                {
                    UpdateProduct(httpClient, product);
                    System.Console.WriteLine(string.Format("Updated Product Id: {0}", product.Id));
                }
                System.Console.WriteLine();

                // Output info on the products
                OutputProductInfo(httpClient);

                System.Console.ReadLine();
            }
        }

        private static IEnumerable<ProductModel> GetProducts(HttpClient httpClient)
        {
            var response = httpClient.GetAsync("http://localhost:49269/productmanagement/products").Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(responseJson);
        }

        private static Guid CreateProduct(HttpClient httpClient, int productNumber)
        {
            var requestJson = new StringContent(string.Format("{{ name: 'Product {0}', description: 'Product {0} description' }}", productNumber), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("http://localhost:49269/productmanagement/products/", requestJson).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Guid>(responseJson);
        }

        private static void UpdateProduct(HttpClient httpClient, ProductModel product)
        {
            var updatedProductName = product.Name + " Updated";
            var updatedProductDescription = product.Description + " updated";
            var requestJson = new StringContent(string.Format("{{ id: '{0}', name: '{1}', description: '{2}' }}", product.Id, updatedProductName, updatedProductDescription), Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync("http://localhost:49269/productmanagement/products/" + product.Id, requestJson).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;            
        }

        private static void OutputProductInfo(HttpClient httpClient)
        {
            var products = GetProducts(httpClient);

            System.Console.WriteLine("Fetching information on products.");
            System.Console.WriteLine();
            System.Console.WriteLine("Count of products in repository: {0}", products.Count());
            System.Console.WriteLine();

            foreach (ProductModel product in products)
            {
                System.Console.WriteLine(string.Format("Product Id: {0}", product.Id));
                System.Console.WriteLine(string.Format("Name: {0}", product.Name));
                System.Console.WriteLine(string.Format("Description: {0}", product.Description));
                System.Console.WriteLine();
            }
        }
    }
}

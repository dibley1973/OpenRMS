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
        public class ItemModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public static void Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                // Delete items if they exist
                System.Console.WriteLine("Deleting existing items.");
                foreach (ItemModel item in GetItems(httpClient))
                {
                    var deleteResponse = httpClient.DeleteAsync("http://localhost:49269/itemmanagement/items/" + item.Id).Result;
                    System.Console.WriteLine(string.Format("Deleted Item Id: {0}", item.Id));
                }
                System.Console.WriteLine();

                // Create some items
                System.Console.WriteLine("Creating some new items");
                for (int i = 0; i < 3; i++)
                {
                    var itemId = CreateItem(httpClient, i + 1);
                    System.Console.WriteLine(string.Format("Created Item Id: {0}", itemId));
                }
                System.Console.WriteLine();

                // Output info on the items
                OutputItemInfo(httpClient);

                // Updating items
                System.Console.WriteLine("Updating items");
                foreach (ItemModel item in GetItems(httpClient))
                {
                    UpdateItem(httpClient, item);
                    System.Console.WriteLine(string.Format("Updated Item Id: {0}", item.Id));
                }
                System.Console.WriteLine();

                // Output info on the items
                OutputItemInfo(httpClient);

                System.Console.ReadLine();
            }
        }

        private static IEnumerable<ItemModel> GetItems(HttpClient httpClient)
        {
            var response = httpClient.GetAsync("http://localhost:49269/itemmanagement/items").Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IEnumerable<ItemModel>>(responseJson);
        }

        private static Guid CreateItem(HttpClient httpClient, int itemNumber)
        {
            var requestJson = new StringContent(string.Format("{{ name: 'Item {0}', description: 'Item {0} description' }}", itemNumber), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("http://localhost:49269/itemmanagement/items/", requestJson).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Guid>(responseJson);
        }

        private static void UpdateItem(HttpClient httpClient, ItemModel item)
        {
            var updatedItemName = item.Name + " Updated";
            var updatedItemDescription = item.Description + " updated";
            var requestJson = new StringContent(string.Format("{{ id: '{0}', name: '{1}', description: '{2}' }}", item.Id, updatedItemName, updatedItemDescription), Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync("http://localhost:49269/itemmanagement/items/" + item.Id, requestJson).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;            
        }

        private static void OutputItemInfo(HttpClient httpClient)
        {
            var items = GetItems(httpClient);

            System.Console.WriteLine("Fetching information on items.");
            System.Console.WriteLine();
            System.Console.WriteLine("Count of items in repository: {0}", items.Count());
            System.Console.WriteLine();

            foreach (ItemModel item in items)
            {
                System.Console.WriteLine(string.Format("Item Id: {0}", item.Id));
                System.Console.WriteLine(string.Format("Name: {0}", item.Name));
                System.Console.WriteLine(string.Format("Description: {0}", item.Description));
                System.Console.WriteLine();
            }
        }
    }
}

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

        public class LocationModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public static void Main(string[] args)
        {
            DoItemOperations();
            DoLocationOperations();

            System.Console.ReadLine();
        }

        private static void DoLocationOperations()
        {
            using (var httpClient = new HttpClient())
            {
                // Delete locations if they exist
                System.Console.WriteLine("Deleting existing locations.");
                foreach (LocationModel location in GetLocations(httpClient))
                {
                    var deleteResponse = httpClient.DeleteAsync("http://localhost:50754/locationmanagement/locations/" + location.Id).Result;
                    System.Console.WriteLine(string.Format("Deleted Location Id: {0}", location.Id));
                }
                System.Console.WriteLine();

                // Create some locations
                System.Console.WriteLine("Creating some new locations");
                for (int i = 0; i < 3; i++)
                {
                    var locationId = CreateLocation(httpClient, i + 1);
                    System.Console.WriteLine(string.Format("Created Location Id: {0}", locationId));
                }
                System.Console.WriteLine();

                // Output info on the locations
                OutputLocationInfo(httpClient);

                // Updating locations
                System.Console.WriteLine("Updating locations");
                foreach (LocationModel location in GetLocations(httpClient))
                {
                    UpdateLocation(httpClient, location);
                    System.Console.WriteLine(string.Format("Updated Location Id: {0}", location.Id));
                }
                System.Console.WriteLine();

                // Output info on the locations
                OutputLocationInfo(httpClient);
            }
        }

        private static void DoItemOperations()
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
            var requestJson = new StringContent(string.Format("{{code: 'Code-{0}', name: 'Item {0}', description: 'Item {0} description' }}", itemNumber), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("http://localhost:49269/itemmanagement/items/", requestJson).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Guid>(responseJson);
        }

        private static void UpdateItem(HttpClient httpClient, ItemModel item)
        {
            var updatedItemName = item.Name + " Updated";
            var updatedItemDescription = item.Description + " updated";
            var requestJson = new StringContent(string.Format("{{ name: '{1}', description: '{2}' }}", item.Id, updatedItemName, updatedItemDescription), Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync("http://localhost:49269/itemmanagement/items/" + item.Id, requestJson).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;            
        }

        private static void OutputItemInfo(HttpClient httpClient)
        {
            var items = GetItems(httpClient).ToList();

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

        private static IEnumerable<LocationModel> GetLocations(HttpClient httpClient)
        {
            var response = httpClient.GetAsync("http://localhost:50754/locationmanagement/locations").Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IEnumerable<LocationModel>>(responseJson);
        }

        private static Guid CreateLocation(HttpClient httpClient, int locationNumber)
        {
            var requestJson = new StringContent(string.Format("{{code: 'Code-{0}', name: 'Location {0}', description: 'Location {0} description' }}", locationNumber), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("http://localhost:50754/locationmanagement/locations/", requestJson).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Guid>(responseJson);
        }

        private static void UpdateLocation(HttpClient httpClient, LocationModel location)
        {
            var updatedLocationName = location.Name + " Updated";
            var updatedLocationDescription = location.Description + " updated";
            var requestJson = new StringContent(string.Format("{{ name: '{1}', description: '{2}' }}", location.Id, updatedLocationName, updatedLocationDescription), Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync("http://localhost:50754/locationmanagement/locations/" + location.Id, requestJson).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;
        }

        private static void OutputLocationInfo(HttpClient httpClient)
        {
            var items = GetLocations(httpClient).ToList();

            System.Console.WriteLine("Fetching information on items.");
            System.Console.WriteLine();
            System.Console.WriteLine("Count of items in repository: {0}", items.Count());
            System.Console.WriteLine();

            foreach (LocationModel item in items)
            {
                System.Console.WriteLine(string.Format("Location Id: {0}", item.Id));
                System.Console.WriteLine(string.Format("Name: {0}", item.Name));
                System.Console.WriteLine(string.Format("Description: {0}", item.Description));
                System.Console.WriteLine();
            }
        }
    }
}

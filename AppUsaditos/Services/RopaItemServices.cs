using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppUsaditos.Model;
using System.Linq;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace AppUsaditos.Services
{
    public class RopaItemServices
    {
        FirebaseClient client;
        public RopaItemServices()
        {
            client = new FirebaseClient("https://appusaditos-default-rtdb.firebaseio.com/");
                
        }

        public async Task<List<ProductoItem>> GetProductoItemsAsync()
        {
            var products =(await client.Child("RopaItems")
                .OnceAsync<ProductoItem>())
                .Select(f =>new ProductoItem
                {
                    CategoryID=f.Object.CategoryID,
                    Description=f.Object.Description,
                    HomeSelected=f.Object.HomeSelected,
                    ImageUrl=f.Object.ImageUrl,
                    Name=f.Object.Name,
                    Price=f.Object.Price,
                    ProductID=f.Object.ProductID,
                    Rating=f.Object.Rating,
                    RatingDetail=f.Object.RatingDetail
                }).ToList();
            return products;
        }
        public async Task<ObservableCollection<ProductoItem>> GetRopaItemsByCategoryAsync(int categoryID)
        {
            var productoItemsByCategory = new ObservableCollection<ProductoItem>();
            var items = (await GetProductoItemsAsync()).Where(p => p.CategoryID == categoryID).ToList();
            foreach (var item in items)
            {
                productoItemsByCategory.Add(item);
            }
            return productoItemsByCategory;
        }
        public async Task<ObservableCollection<ProductoItem>> GetLatestProductoItemsAsync()
        {
            var latestProductoItems = new ObservableCollection<ProductoItem>();
            var items = (await GetProductoItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);
            foreach (var item in items)
            {
                latestProductoItems.Add(item);
            }
            return latestProductoItems;
        }
    }
}

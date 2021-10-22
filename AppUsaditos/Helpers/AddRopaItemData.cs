using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppUsaditos.Model;
using Firebase.Database;
using Firebase.Database.Query;
using static System.Net.Mime.MediaTypeNames;

namespace AppUsaditos.Helpers
{
    public class AddRopaItemData
    {
        FirebaseClient client;

        public List<ProductoItem> ProductoItems { get; set; }
        
        public AddRopaItemData()
        {
            client = new FirebaseClient("https://appusaditos-default-rtdb.firebaseio.com/");
            ProductoItems = new List<ProductoItem>()
            {
                new ProductoItem
                {
                    ProductID=1,
                    CategoryID=1,
                    ImageUrl="https://i.blogs.es/666188/honor-vision-pro-tv/450_1000.jpg",
                    Name="pantalon jean",
                    Description="talla m color azul",
                    Rating="4.3",
                    RatingDetail="(121 raiting)",
                    HomeSelected="https://cdn-icons.flaticon.com/png/512/2951/premium/2951141.png?token=exp=1633908544~hmac=88082484e429b992d3817651b42b9e03",
                    Price=25
                },

                new ProductoItem
                {
                    ProductID=2,
                    CategoryID=1,
                    ImageUrl="favorito.png",
                    Name="polo liviano",
                    Description="gbfdx",
                    Rating="4",
                    RatingDetail="(121 raiting)",
                    HomeSelected="CompleteHeart",
                    Price=25
                },
                new ProductoItem
                {
                    ProductID=3,
                    CategoryID=1,
                    ImageUrl="favorito.png",
                    Name="short",
                    Description="dsvdfb",
                    Rating="5",
                    RatingDetail="(121 raiting)",
                    HomeSelected="CompleteHeart",
                    Price=25
                }


            };
        }

        public async Task AddRopaItemAsync()
        {
            try
            {
                foreach (var item in ProductoItems)
                {
                    await client.Child("ProductoItems").PostAsync(new ProductoItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        Description = item.Description,
                        HomeSelected = item.HomeSelected,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Price = item.Price,
                        Rating = item.Rating,
                        RatingDetail=item.RatingDetail
                    }) ;
                }
            }
            catch (Exception ex)
            {
                //await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

    }
}

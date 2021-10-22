using System;
using System.Collections.Generic;
using System.Text;
using AppUsaditos.Model;
using Firebase.Database;
using System.Threading.Tasks;
using Firebase.Database.Query;
using static System.Net.Mime.MediaTypeNames;

namespace AppUsaditos.Helpers
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }
        FirebaseClient client;

        public AddCategoryData()
        {
            client = new FirebaseClient("https://appusaditos-default-rtdb.firebaseio.com/");
            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryID = 1,
                    CategoryName = "Ropa",
                    CategoryPoster = "MainRopa",
                    ImageUrl = "https://cdn-icons-png.flaticon.com/512/1016/1016656.png",
                    Imagendos ="favorito.png"
                },
                new Category()
                {
                    CategoryID = 2,
                    CategoryName = "Electronicos",
                    CategoryPoster = "MainElectronicos",
                    ImageUrl = "https://cdn-icons-png.flaticon.com/512/1262/1262694.png",
                    Imagendos ="favorito.png"
                },
                new Category()
                {
                    CategoryID = 3,
                    CategoryName = "Muebles",
                    CategoryPoster = "MainMuebles",
                    ImageUrl = "https://cdn-icons-png.flaticon.com/512/4803/4803547.png",
                    Imagendos ="favorito.png"
                },
                new Category()
                {
                    CategoryID = 4,
                    CategoryName = "Libros",
                    CategoryPoster = "MainLibros",
                    ImageUrl = "https://cdn-icons-png.flaticon.com/128/2702/2702069.png",
                    Imagendos ="favorito.png"
                }
            };

        }
        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
                    });
                }
            }
            catch (Exception ex)
            {
                //await Application.Current.MainPage.DisplayAlert("error", ex.Message, "OK");
            }
        }
    }
}
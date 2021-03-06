using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppUsaditos.Helpers;

namespace AppUsaditos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private async void ButtonCategories_Clicked(object sender, EventArgs e)
        {
            var acd = new AddCategoryData();
            await acd.AddCategoriesAsync();
        }

        private async void ButtonProducts_Clicked(object sender, EventArgs e)
        {
            var afd = new AddRopaItemData();
            await afd.AddRopaItemAsync();
        }
    }
}
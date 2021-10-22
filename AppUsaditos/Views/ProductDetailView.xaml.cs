using AppUsaditos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppUsaditos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailView : ContentPage
    {
        public ProductDetailView(ProductoItem productoItem)
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
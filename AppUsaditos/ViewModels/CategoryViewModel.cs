using AppUsaditos.Model;
using AppUsaditos.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppUsaditos.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }
            get
            {
                return _SelectedCategory;
            }
        }
        public ObservableCollection<ProductoItem> RopaItemsByCategory { get; set; }
        private int _TotalRopaItems;
        public int TotalRopaItems
        {
            set
            {
                _TotalRopaItems = value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalRopaItems;
            }
        }
        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            RopaItemsByCategory = new ObservableCollection<ProductoItem>();
            GetFoodItems(category.CategoryID);
        }

        private async void GetFoodItems(int categoryID)
        {
            var data = await new RopaItemServices().GetRopaItemsByCategoryAsync(categoryID);
            RopaItemsByCategory.Clear();
            foreach (var item in data)
            {
                RopaItemsByCategory.Add(item);
            }
            TotalRopaItems = RopaItemsByCategory.Count;
        }
    }
}

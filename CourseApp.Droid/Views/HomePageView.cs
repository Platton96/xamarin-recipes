using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CourseApp.Core;
using CourseApp.Droid.Views.Adapters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace CourseApp.Droid.Views
{
    [Activity(Label = "Dishes")]
    public class HomePageView : MvxAppCompatActivity<HomePageViewModel>
    {
        private MvxRecyclerView _recyclerView;
        private DishesCategoryAdapter _adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _adapter = new DishesCategoryAdapter((IMvxAndroidBindingContext)BindingContext, Resources);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainPage);
            InitComponents();
            ApplyBindings();
        
        }
        private void InitComponents()
        {
            var citiesLayoutManager = new GridLayoutManager(ApplicationContext, 3);        
        

            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.dishes_category_list);
            _recyclerView.SetLayoutManager(citiesLayoutManager);
            _recyclerView.Adapter = _adapter;
        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<HomePageView, HomePageViewModel>();
            bindingSet.Bind(_adapter).For(b => b.DishesCategoryClick).To(vm => vm.NavigateToRecipesAsyncCommand);
            bindingSet.Bind(_adapter).For(b => b.ItemsSource).To(vm => vm.DishesCategories);

            bindingSet.Apply();
        }
    }
}
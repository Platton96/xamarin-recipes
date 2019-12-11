using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
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
    [Activity(Label = "Главная страница")]
    public class HomePageView : MvxAppCompatActivity<HomePageViewModel>
    {
        private MvxRecyclerView _recyclerView;
        private DishesCategoryAdapter _adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _adapter = new DishesCategoryAdapter((IMvxAndroidBindingContext)BindingContext);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.HomePage);
            InitComponents();
            ApplyBindings();
        
        }
        private void InitComponents()
        {
            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.dishes_category_list);
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
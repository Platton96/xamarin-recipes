using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CourseApp.Core.ViewModels;
using CourseApp.Droid.Converters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace CourseApp.Droid.Views
{
    [Activity(Label = "RecipeDetails")]
    public class RecipeDetailsView : MvxAppCompatActivity<RecipeDetailsViewModel>
    {
        private TextView _recipeDescription;
        private TextView _recipeTitle;
        private ImageView _recipeImage;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.RecipeDetailsPage);
            InitComponents();
            ApplyBindings();
        }

        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<RecipeDetailsView, RecipeDetailsViewModel>();
            bindingSet.Bind(_recipeDescription)
                .For(x => x.Text)
                .To(vm => vm.RecipeDescription).OneWay();
            bindingSet.Bind(_recipeTitle)
              .For(x => x.Text)
               .To(vm => vm.RecipeTitle).OneWay();
            bindingSet.Bind(_recipeImage)
                .For(x => x.Drawable)
                .To(vm => vm.RecipeTitle).WithConversion<NameAssetsImageToImageConverter>()
                .OneWay();
            bindingSet.Apply();
        }

        private void InitComponents()
        {
            _recipeTitle = FindViewById<TextView>(Resource.Id.text_recipe_details_title);
            _recipeDescription = FindViewById<TextView>(Resource.Id.text_recipe_details_decription);
            _recipeImage = FindViewById<ImageView>(Resource.Id.image_recipe_details);
        }
    }
}
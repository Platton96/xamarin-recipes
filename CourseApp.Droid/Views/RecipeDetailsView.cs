using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CourseApp.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace CourseApp.Droid.Views
{
    [Activity(Label = "RecipeDetails")]
    public class RecipeDetailsView : MvxAppCompatActivity<RecipeDetailsViewModel>
    {
        private TextView _recipeDescription;
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

            bindingSet.Apply();
        }

        private void InitComponents()
        {
            _recipeDescription = FindViewById<TextView>(Resource.Id.text_recipe_details_decription);
            _recipeImage = FindViewById<ImageView>(Resource.Id.image_recipe_details);

            var imageUri = Android.Net.Uri.Parse(ViewModel.RecipeImagePath);
            _recipeImage.SetImageURI(imageUri);
        }
    }
}
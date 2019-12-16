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
using CourseApp.Core.Models;
using CourseApp.Droid.Converters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Uri = Android.Net.Uri;

namespace CourseApp.Droid.Views.ViewHolders
{
    public class RecipeViewHolder : MvxRecyclerViewHolder
    {
        private LinearLayout _recipeItemCell;
        private TextView _recipeTitle;
        private ImageView _recipeImage;

        public event EventHandler RecipeClicked;
        public RecipeViewHolder(View itemView, IMvxAndroidBindingContext context) :  base(itemView, context)
        {
            InitComponents(itemView);
            ApplyBindings();
        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<RecipeViewHolder, Recipe>();

            bindingSet.Bind(_recipeTitle)
                .For(p => p.Text)
                .To(vm => vm.Title).
                OneWay();
            bindingSet.Bind(_recipeImage)
                .For(x => x.Drawable)
                .To(vm => vm.Title).WithConversion<NameAssetsImageToImageConverter>()
                .OneWay();
            bindingSet.Apply();
        }
        private void InitComponents(View itemView)
        {
            _recipeItemCell = itemView.FindViewById<LinearLayout>(Resource.Id.linear_layout_recipe);
            _recipeTitle = itemView.FindViewById<TextView>(Resource.Id.text_recipe_title);
            _recipeImage = itemView.FindViewById<ImageView>(Resource.Id.image_recipe);

            _recipeItemCell.Click += (s, e) =>
            {
                RecipeClicked(DataContext as Recipe, null);

            };

        }

        
    }
}
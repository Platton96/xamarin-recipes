using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CourseApp.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace CourseApp.Droid.Views.ViewHolders
{
    public class DishesCategoryValueViewHolder : MvxRecyclerViewHolder
    {
        private LinearLayout _dishesCategoryItemCell;
        private TextView _dishesCategoryTitle;
        private ImageView _dishesCategoryImage;

        public event EventHandler DishesCategoryImageClicked;

        public DishesCategoryValueViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {

        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<DishesCategoryValueViewHolder, DishesCategory>();

            bindingSet.Bind(_dishesCategoryTitle)
                .For(p => p.Text)
                .To(vm => vm.Name);
            bindingSet.Apply();
        }
        private void InitComponents(View itemView)
        {
            _dishesCategoryItemCell = itemView.FindViewById<LinearLayout>(Resource.Id.linear_layout_dishes_category);
            _dishesCategoryTitle = itemView.FindViewById<TextView>(Resource.Id.text_view_image_title);
            _dishesCategoryImage = itemView.FindViewById<ImageView>(Resource.Id.image_view_dishes_category);
           
            _dishesCategoryItemCell.Click+= (s, e) =>
            {
                DishesCategoryImageClicked(DataContext as DishesCategory, null);
            };
            
        }

        private void SetImageDishesCategory(string nameImage)
        {
            //var imageResourseId= Resources.GetIdentifier(nameImage, "drawable", C);
           // _dishesCategoryImage.SetImageResource(Resource.Id.soups)
        }
    }
}
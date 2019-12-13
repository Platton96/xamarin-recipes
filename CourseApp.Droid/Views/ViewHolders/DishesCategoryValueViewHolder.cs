using System;
using Android.Content.Res;
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
        private Resources _resources;

        public event EventHandler DishesCategoryImageClicked;

        public DishesCategoryValueViewHolder(View itemView, IMvxAndroidBindingContext context, Resources resourcesWithImage) : base(itemView, context)
        {
            _resources = resourcesWithImage;
            InitComponents(itemView);
            ApplyBindings();
      

        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<DishesCategoryValueViewHolder, DishesCategory>();

            bindingSet.Bind(_dishesCategoryTitle)
                .For(p => p.Text)
                .To(vm => vm.Name ).
                OneWay();
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

            _dishesCategoryItemCell.ViewAttachedToWindow+= (s, e) =>
            {
                var dishesCategoryFileName = (DataContext as DishesCategory)?.FileName;

                if (!string.IsNullOrEmpty(dishesCategoryFileName))
                {
                    SetImageDishesCategory(dishesCategoryFileName, _resources);
                }
            };


        }

        private void SetImageDishesCategory(string nameImage, Resources resourcesWithImage)
        {

           var resourceImgeId = resourcesWithImage.GetIdentifier(nameImage, "drawable", "com.companyname.courseapp.droid");
           _dishesCategoryImage.SetImageResource(resourceImgeId);
        }
    }
}
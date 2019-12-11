using Android.Views;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace CourseApp.Droid.Views.Adapters
{
    internal class DishesCategoryViewHolder
    {
        private View view;
        private MvxAndroidBindingContext itemBindingContext;
        private object _showCityMap;

        public DishesCategoryViewHolder(View view, MvxAndroidBindingContext itemBindingContext, object showCityMap)
        {
            this.view = view;
            this.itemBindingContext = itemBindingContext;
            _showCityMap = showCityMap;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using CourseApp.Droid.Views.ViewHolders;

namespace CourseApp.Droid.Views.Adapters
{
    public class DishesCategoryAdapter : MvxRecyclerAdapter
    {
        public ICommand DishesCategoryClick { get; set; }

        public DishesCategoryAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
        {
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext?.LayoutInflaterHolder);
            var view = itemBindingContext.BindingInflate(Resource.Layout.dishes_category_item_template, parent, false);

            var viewHolder = new DishesCategoryValueViewHolder(view, itemBindingContext);
            viewHolder.DishesCategoryImageClicked += (s, e) =>
            {
                DishesCategoryClick.Execute(s);
            };

            return viewHolder;
        }
    }
}
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
using CourseApp.Droid.Views.ViewHolders;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace CourseApp.Droid.Views.Adapters
{
    public class RecipeAdapter : MvxRecyclerAdapter
    {
        public ICommand RecipeClick { get; set; }
        public ICommand EditRecipeClick { get; set; }

        public RecipeAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
        {

        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext?.LayoutInflaterHolder);
            var view = itemBindingContext.BindingInflate(Resource.Layout.recipe_item, parent, false);

            var viewHolder = new RecipeViewHolder(view, itemBindingContext);

            viewHolder.RecipeClicked += (s, e) =>
            {
                RecipeClick.Execute(s);
            };

            viewHolder.EditRecipeClicked += (s, e) =>
              {
                  EditRecipeClick.Execute(s);
              };

            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);
        }
    }
}
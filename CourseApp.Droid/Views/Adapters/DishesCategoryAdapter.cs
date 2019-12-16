using System.Windows.Input;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using CourseApp.Droid.Views.ViewHolders;
using Android.Content.Res;

namespace CourseApp.Droid.Views.Adapters
{
    public class DishesCategoryAdapter : MvxRecyclerAdapter
    {
        public ICommand DishesCategoryClick { get; set; }
        private readonly Resources _resourceseWithImage;
        public DishesCategoryAdapter(IMvxAndroidBindingContext bindingContext, Resources resourseWithImage) : base(bindingContext)
        {
            _resourceseWithImage = resourseWithImage;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext?.LayoutInflaterHolder);
            var view = itemBindingContext.BindingInflate(Resource.Layout.dishes_caategory_item, parent, false);

            var viewHolder = new DishesCategoryValueViewHolder(view, itemBindingContext, _resourceseWithImage);
            viewHolder.DishesCategoryImageClicked += (s, e) =>
            {
                DishesCategoryClick.Execute(s);
            };

            return viewHolder;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);
        }
    }
}
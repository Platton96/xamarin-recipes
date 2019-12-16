using Android.App;
using Android.OS;
using Android.Widget;
using CourseApp.Core.ViewModels;
using CourseApp.Droid.Views.Adapters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace CourseApp.Droid.Views
{
    [Activity(Label = "Recipes")]
    public class RecipesView : MvxAppCompatActivity<RecipesViewModel>
    {
        private MvxRecyclerView _recyclerView;
        private RecipeAdapter _adapter;
        private Button _addingRecipeButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _adapter = new RecipeAdapter((IMvxAndroidBindingContext)BindingContext);
            SetContentView(Resource.Layout.RecipesPage);
            InitComponents();
            ApplyBindings();
        }
        private void InitComponents()
        {
            _addingRecipeButton = FindViewById<Button>(Resource.Id.button_add_recipe);
            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recipe_list);
            _recyclerView.Adapter = _adapter;
        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<RecipesView, RecipesViewModel>();
            bindingSet.Bind(_addingRecipeButton).To(vm => vm.NavigateToAddingRecipeAsyncCommand);
            bindingSet.Bind(_adapter).For(b => b.ItemsSource).To(vm => vm.DishesCategoryRecipes);
            bindingSet.Bind(_adapter).For(b => b.RecipeClick).To(vm => vm.NavigateToRecipeDetailsAsyncCommand);
            bindingSet.Bind(_adapter).For(b => b.EditRecipeClick).To(vm => vm.NavigateToEdingRecipeAsyncCommand);

            bindingSet.Apply();
        }
    }
}
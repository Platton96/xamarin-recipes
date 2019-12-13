using Android.App;
using Android.OS;
using Android.Widget;
using CourseApp.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace CourseApp.Droid.Views
{
    [Activity(Label = "Recipes")]
    public class RecipesView : MvxAppCompatActivity<RecipesViewModel>
    {
        private Button _addingRecipeButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.RecipesPage);
            InitComponents();
            ApplyBindings();
        }
        private void InitComponents()
        {
            _addingRecipeButton = FindViewById<Button>(Resource.Id.button_add_recipe);

        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<RecipesView, RecipesViewModel>();
            bindingSet.Bind(_addingRecipeButton).To(vm => vm.NavigateToAddingRecipeAsyncCommand);

            bindingSet.Apply();
        }
    }
}
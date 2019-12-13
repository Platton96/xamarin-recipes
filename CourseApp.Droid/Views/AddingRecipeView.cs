using Android.App;
using Android.OS;
using CourseApp.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace CourseApp.Droid.Views
{
    [Activity(Label = "AddingRecipe")]
    public class AddingRecipeView : MvxAppCompatActivity<AddingRecipeViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddingRecipePage);
        }

        private void InitComponents()
        {
           

        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<AddingRecipeView, AddingRecipeViewModel>();
    

            bindingSet.Apply();
        }
    }
}
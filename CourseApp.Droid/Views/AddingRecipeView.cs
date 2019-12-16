using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using CourseApp.Core.ViewModels;
using CourseApp.Droid.Converters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using System;
using System.IO;

namespace CourseApp.Droid.Views
{
    [Activity(Label = "AddingRecipe")]
    public class AddingRecipeView : MvxAppCompatActivity<AddingRecipeViewModel>
    {
        private const string IMAGE_TYPE = "image/*";
        private const string CREATE_CHOOSER_TITLE = "Select Picture";
        private const string FAILED_SAVING_MESSAGE = "Рецепт не удалось сохранить";
        private const string SUCCESFUL_SAVING_MESSAGE_TEMPLATE = "{0} упешно сахранен";

        private EditText _recipeTitle;
        private EditText _recipeDescription;
        private AppCompatButton _addImageRecipeButton;
        private AppCompatButton _saveRecipeButton;
        private ImageView _recipeImage;
        public static readonly int PickImageId = 1000;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddingRecipePage);
            InitComponents();
            ApplyBindings();
        }

        private void InitComponents()
        {
            Intent = new Intent();

            _recipeTitle = FindViewById<EditText>(Resource.Id.input_reciple_title);
            _recipeDescription = FindViewById<EditText>(Resource.Id.input_reciple_description);
            _addImageRecipeButton = FindViewById<AppCompatButton>(Resource.Id.btn_add_image);
            _saveRecipeButton = FindViewById<AppCompatButton>(Resource.Id.btn_save_reciple);
            _recipeImage = FindViewById<ImageView>(Resource.Id.imageView_adding_image);

            _addImageRecipeButton.Click += OnAddImageButtonClick;
            _saveRecipeButton.Click += OnSaveRecipeButtonClick;

        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<AddingRecipeView, AddingRecipeViewModel>();
            bindingSet.Bind(_recipeTitle)
                .For(x => x.Text)
                .To(vm => vm.RecipeTitle).TwoWay();
            bindingSet.Bind(_recipeDescription)
                .For(x => x.Text)
                .To(vm => vm.RecipeDescription).TwoWay();
            bindingSet.Bind(_recipeImage)
                    .For(x => x.Drawable)
                    .To(vm => vm.RecipeTitle).WithConversion<NameAssetsImageToImageConverter>()
                     .OneWay();

            bindingSet.Apply();
        }
        private void OnAddImageButtonClick(object sender, EventArgs eventArgs)
        {
            Intent.SetType(IMAGE_TYPE);
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, CREATE_CHOOSER_TITLE), PickImageId);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent imageData)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (imageData != null))
            {
                var imageUri = imageData.Data;
                var imageBytes = ConvertImageUriToByte(imageUri);

                ViewModel.RecipeImageBytes = imageBytes;

                _recipeImage.SetImageURI(imageUri);
            }
        }
        private async void OnSaveRecipeButtonClick(object sender, EventArgs eventArgs)
        {
            var savedRecipe = await ViewModel.SaveRecipeAsync();

            if (savedRecipe == null)
            {
                Toast.MakeText(this, FAILED_SAVING_MESSAGE, ToastLength.Long).Show();
                return;
            }

            Toast.MakeText(this, 
                string.Format(SUCCESFUL_SAVING_MESSAGE_TEMPLATE, savedRecipe.Title),
                ToastLength.Long)
                .Show();
        }

        public byte[] ConvertImageUriToByte(Android.Net.Uri uri)
        {
            Stream stream = ContentResolver.OpenInputStream(uri);
            byte[] byteArray;

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                byteArray = memoryStream.ToArray();
            }
            return byteArray;
        }
    }
}
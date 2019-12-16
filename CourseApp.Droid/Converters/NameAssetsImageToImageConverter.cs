using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;

namespace CourseApp.Droid.Converters
{
    public class NameAssetsImageToImageConverter : MvxValueConverter<string, Drawable>
    {
        
        protected override Drawable Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            var currentActivity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            var decodedByte = BitmapFactory.DecodeFile($"{currentActivity.FilesDir}/{value}");
            var image = new BitmapDrawable(currentActivity.Resources, decodedByte);

            return image;
        }
    }
}
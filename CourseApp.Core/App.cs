using CourseApp.Core.Infarstructure;
using CourseApp.Core.Data;
using CourseApp.Core.Service;
using CourseApp.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace CourseApp.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IRecipesService, RecipesService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IRecipesRepository, RecipesRepository>();   

            RegisterAppStart<HomePageViewModel>();
		}

	}
}

using CourseApp.Core.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			RegisterAppStart<HomePageViewModel>();
			// if you want to use a custom AppStart, you should replace the previous line with this one:
			// RegisterCustomAppStart<MyCustomAppStart>();
		}

	}
}

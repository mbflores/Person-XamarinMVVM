using System;
using PersonMVVM.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace PersonMVVM
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage =new NavigationPage(new PersonPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

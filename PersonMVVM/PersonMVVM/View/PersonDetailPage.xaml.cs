using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonMVVM.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonMVVM.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonDetailPage : ContentPage
	{
		public PersonDetailPage (PersonVM person)
		{
		    BindingContext = person;
			InitializeComponent ();
		}
	}
}
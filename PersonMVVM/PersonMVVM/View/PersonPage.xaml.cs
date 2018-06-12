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
	public partial class PersonPage : ContentPage
	{
		public PersonPage ()
		{
		    BindingContext = new PersonsVM(new PageService());
			InitializeComponent ();
		}

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as PersonsVM).SelectPersonCommand.Execute(e.SelectedItem);
        }
    }
}
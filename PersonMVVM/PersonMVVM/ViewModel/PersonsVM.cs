using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PersonMVVM.Model;
using PersonMVVM.View;
using Xamarin.Forms;

namespace PersonMVVM.ViewModel
{
    class PersonsVM:BaseVM
    {
        private PersonVM _selectedPerson;
        private readonly IPageService _pageService;
        public ObservableCollection<PersonVM> _person { get; private set; } = new ObservableCollection<PersonVM>();

        public ICommand OnAdd { get; set; }
        public ICommand OnDelete{ get; set; }
        public ICommand OnUpdate { get; set; }
        public ICommand SelectPersonCommand { get; set; }

        public PersonsVM(IPageService pageService)
        {
            _pageService = pageService;
            OnAdd = new Command(Add);
            OnDelete = new Command(Delete);
            OnUpdate = new Command(Update);
            SelectPersonCommand = new Command<PersonVM>(async vm => await SelectedPerson(vm));
        }
        

        public PersonVM SelectPerson
        {
            get { return _selectedPerson; }
            set
            {
                SetValue(ref _selectedPerson, value);
                OnPropertyChanged();
            }
        }


        public void Add()
        {
            var person = new PersonVM {Id=_person.Count+1,Name = $"Person {_person.Count+1}"};
            _person.Add(person);

        }

        public void Delete()
        {
            if (_person.Count == 0)
            {
                _pageService.DisplayAlert("ERROR", "NO STUFFS LISTED", "OK", "CANCEL");
            }
            else
            {
                
                var person = _person[_person.Count - 1];
                _person.Remove(person);
            }

        }
        public void Update()
        {
            if (_person.Count == 0)
            {
                _pageService.DisplayAlert("ERROR", "NO STUFFS LISTED", "OK", "CANCEL");
            }
            else
            {
                
                var person = _person[_person.Count - 1];
                person.Name += "Update";
            }

        }

        public async Task SelectedPerson(PersonVM person)
        {
            if (person == null)
            {
                return;
            }
            SelectPerson=null;
            await _pageService.PushAsync(new PersonDetailPage(person));


        }
    }
}

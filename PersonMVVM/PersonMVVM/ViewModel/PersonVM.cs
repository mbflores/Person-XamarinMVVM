using System;
using System.Collections.Generic;
using System.Text;

namespace PersonMVVM.ViewModel
{
   public class PersonVM:BaseVM
    {
        public int Id { get; set; }
        private string _name;
        public string Name {
            get { return _name; }
            set
            {
                SetValue(ref _name, value);
                OnPropertyChanged();
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WorkersData
{
    class Person : INotifyPropertyChanged , IDataErrorInfo
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                    _name = value;
                    OnPropertyChanged("Name");
            } 
        }
        public int Salary { get; set; }

        public string Job_Title {  get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int NumberOfHouse { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();

        public Person() { }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string info = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}

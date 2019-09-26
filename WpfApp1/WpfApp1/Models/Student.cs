using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    [CollectionDataContract]
    public class Student : INotifyPropertyChanged
    {
        string name;
        string lastname;
        int year;
        string group;

        [DataMember]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                Notify();
            }
        }
        [DataMember]
        public string Lastname
        {
            get => lastname;
            set
            {
                lastname = value;
                Notify();
            }
        }
        [DataMember]
        public int Year
        {
            get => year;
            set
            {
                year = value;
                Notify();
            }
        }
        [DataMember]
        public string Group
        {
            get => group;
            set
            {
                group = value;
                Notify();
            }
        }

        protected void Notify([CallerMemberName]string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

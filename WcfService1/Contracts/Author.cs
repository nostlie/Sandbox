using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace WcfService1.Contracts
{
    public class Author : INotifyPropertyChanged
    {
#region Inherited implentations
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
#endregion

        private int _authorId;
        private string _name;
        private string _bio;
        private string _hometown;
        private int _age;

        public int AuthorId
        {
            get { return _authorId; }
            set
            {
                if ((_authorId == null && value != null) || (_authorId != null && !_authorId.Equals(value)))
                {
                    _authorId = value;
                    OnPropertyChanged("AuthorId");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if ((_name == null && value != null) || (_name != null && !_name.Equals(value)))
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Bio
        {
            get { return _bio; }
            set
            {
                if ((_bio == null && value != null) || (_bio != null && !_bio.Equals(value)))
                {
                    _bio = value;
                    OnPropertyChanged("Bio");
                }
            }
        }

        public string Hometown
        {
            get { return _hometown; }
            set
            {
                if ((_hometown == null && value != null) || (_hometown != null && !_hometown.Equals(value)))
                {
                    _hometown = value;
                    OnPropertyChanged("Hometown");
                }
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if ((_age == null && value != null) || (_age != null && !_age.Equals(value)))
                {
                    _age = value;
                    OnPropertyChanged("Age");
                }
            }
        }
    }
}

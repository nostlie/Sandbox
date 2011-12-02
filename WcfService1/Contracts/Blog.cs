using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace WcfService1.Contracts
{
    public class Blog : INotifyPropertyChanged
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

        private int _blogId;
        private string _title;
        private string _description;
        private Author _author;

        public int BlogId
        {
            get { return _blogId; }
            set
            {
                if ((_blogId == null && value != null) || (_blogId != null && !_blogId.Equals(value)))
                {
                    _blogId = value;
                    OnPropertyChanged("BlogId");
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if ((_title == null && value != null) || (_title != null && !_title.Equals(value)))
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if ((_description == null && value != null) || (_description != null && !_description.Equals(value)))
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public Author Author
        {
            get { return _author; }
            set
            {
                if ((_author == null && value != null) || (_author != null && !_author.Equals(value)))
                {
                    _author = value;
                    OnPropertyChanged("Author");
                }
            }
        }        
    }
}

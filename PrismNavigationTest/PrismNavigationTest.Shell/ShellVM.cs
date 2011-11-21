using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Events;
using PrismNavigationTest.Infrastructure;
using System.Windows.Browser;
using System.ComponentModel;
using System.Collections.Generic;

namespace PrismNavigationTest.Shell
{
    public class ShellVM : DependencyObject, IShell
    {
        private IEventAggregator _eventAggregator;

        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<String, List<String>> _errors = new Dictionary<string, List<string>>();

        public Dictionary<String, List<String>> Errors
        {
            get
            {
                return _errors;
            }
        }

        public static readonly DependencyProperty IsBusyProperty =
        DependencyProperty.Register("IsBusy", typeof(bool), typeof(Shell), new PropertyMetadata(false));
        public bool IsBusy
        {
            get
            {
                return (bool)GetValue(IsBusyProperty);
            }
            set
            {
                SetValue(IsBusyProperty, value);
            }
        }

        public static readonly DependencyProperty FrameSourceProperty =
        DependencyProperty.Register("FrameSource", typeof(string), typeof(Shell), new PropertyMetadata(""));
        public string FrameSource
        {
            get
            {
                return (string)GetValue(FrameSourceProperty);
            }
            set
            {
                SetValue(FrameSourceProperty, value);
            }
        }

        public static readonly DependencyProperty ContentLoaderProperty =
        DependencyProperty.Register("ContentLoader", typeof(INavigationContentLoader), typeof(ShellVM), new PropertyMetadata(null));

        public ShellVM(IServiceLocator serviceLocator)
        {
            SetValue(ContentLoaderProperty, serviceLocator.GetInstance<INavigationContentLoader>());
            _eventAggregator = serviceLocator.GetInstance<IEventAggregator>();
            _eventAggregator.GetEvent<ActivateView>().Publish(new ViewActivation { NavigateTo = "View1", NavigateFrom = "View1" });
        }

        public void SetPageTitle()
        {
            HtmlPage.Document.SetProperty("title", "PrismNavigationTest");
        }

        public bool HasErrors
        {
            get
            {
                return _errors.Count > 0;
            }
        }

        public string Error
        {
            get
            {
                string ret = null;
                if (HasErrors)
                {
                    ret = BuildErrorText(Errors);
                }
                return ret;
            }
        }

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName))
                return null;
            return _errors[propertyName];
        }

        public void AddError(string propertyName, string errorText, bool isWarning)
        {
            if (!_errors.ContainsKey(propertyName))
                _errors[propertyName] = new List<string>();

            if (!_errors[propertyName].Contains(errorText))
            {
                if (isWarning)
                    _errors[propertyName].Add(errorText);
                else
                    _errors[propertyName].Insert(0, errorText);
                RaiseErrorsChanged(propertyName);
            }
        }

        // Removes the specified error from the errors collection if it is
        // present. Raises the ErrorsChanged event if the collection changes.
        public void RemoveError(string propertyName, string errorText)
        {
            if (_errors.ContainsKey(propertyName) && _errors[propertyName].Contains(errorText))
            {
                _errors[propertyName].Remove(errorText);
                if (_errors[propertyName].Count == 0)
                    _errors.Remove(propertyName);
                RaiseErrorsChanged(propertyName);
            }
        }

        public void ClearErrors()
        {
            string[] propertyNames = new string[_errors.Keys.Count];
            _errors.Keys.CopyTo(propertyNames, 0);
            _errors.Clear();
            foreach (string propertyName in propertyNames)
            {
                RaiseErrorsChanged(propertyName);
            }
        }

        protected virtual void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            // Fire property change events for Error and HasErrors
            PropertyChanged(this, new PropertyChangedEventArgs("Error"));
            PropertyChanged(this, new PropertyChangedEventArgs("HasErrors"));            
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected string BuildErrorText(Dictionary<string, List<string>> dictionary)
        {
            string ret = "";
            foreach (KeyValuePair<string, List<string>> kv in dictionary)
            {
                if (!string.IsNullOrEmpty(ret))
                {
                    ret += "\n";
                }
                ret += BuildErrorText(kv.Key, kv.Value);
            }
            return ret;
        }

        protected string BuildErrorText(string propertyName, List<string> errors)
        {
            string ret = null;
            if (errors != null && errors.Count > 0)
            {
                ret = "";
                foreach (string error in errors)
                {
                    if (!string.IsNullOrEmpty(ret))
                    {
                        ret += "\n";
                    }
                    ret += error;
                }
            }
            return ret;
        }

        public string this[string columnName]
        {
            get
            {
                return BuildErrorText(columnName, Errors[columnName]);
            }
        }
    }
}

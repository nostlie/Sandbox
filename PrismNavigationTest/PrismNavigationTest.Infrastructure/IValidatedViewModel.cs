using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PrismNavigationTest.Infrastructure
{
    public interface IValidatedViewModel : INotifyDataErrorInfo, IDataErrorInfo, INotifyPropertyChanged
    {
        Dictionary<String, List<String>> Errors { get; }
        void ClearErrors();
        void RemoveError(string propertyName, string errorText);
        void AddError(string propertyName, string errorText, bool isWarning);
    }
}

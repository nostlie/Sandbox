using System.Windows;

namespace PrismNavigationTest.Infrastructure
{
    public interface IShell : IValidatedViewModel
    {
        bool IsBusy { get; set; }
        string FrameSource { get; set; }
        void SetPageTitle();
        
    }
}

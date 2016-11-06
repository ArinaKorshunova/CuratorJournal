using System.Windows;
using System.Windows.Navigation;

namespace CuratorJournal.NavigationHelper
{
    public class Navigation : INavigation
    {
        public void NavigateTo(object navigationTarget)
        {
            NavigationWindow win = (NavigationWindow)Application.Current.MainWindow;
            win.Content = navigationTarget;
            win.Show();
        }

        public void NavigateTo(object navigationTarget, object navigationContext)
        {
            NavigationWindow win = (NavigationWindow)Application.Current.MainWindow;
            win.DataContext = navigationContext;
            win.Content = navigationTarget;
            win.Show();
        }
    }
}

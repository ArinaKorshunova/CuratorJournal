namespace CuratorJournal.NavigationHelper
{
    public interface INavigation
    {
        void NavigateTo(object navigationTarget);
        void NavigateTo(object navigationTarget, object navigationContext);
    }
}

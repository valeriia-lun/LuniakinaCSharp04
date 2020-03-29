
namespace Luniakina04.Tools.Navigation
{
    internal enum ViewType
    {
        TableView,
        AddPersonView,
        EditPersonView
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}

namespace UserInterface.UserControls.ViewModels
{
    public interface IListViewModel
    {
        string Name { get; }

        void OnItemsChanged();
    }
}
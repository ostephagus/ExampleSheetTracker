using DataManager;
using System.ComponentModel;
using System.Windows.Controls;
using UserInterface.UserControls.ViewModels;
using UserInterface.UserControls.Views;

namespace UserInterface
{
    public class AppVM : ViewModelBase
    {
        private Part[] data;
        private UserControl currentUserControl;
        private Serialiser serialiser;
        
        private BindingList<WindowContainer> navigationStack;
        public BindingList<WindowContainer> NavigationStack
        {
            get => navigationStack;
            set
            {
                navigationStack = value;
                OnPropertyChanged(this, nameof(NavigationStack));
            }
        }
        public UserControl CurrentUserControl
        {
            get => currentUserControl;
            set
            {
                currentUserControl = value;
                OnPropertyChanged(this, nameof(CurrentUserControl));
            }
        }

        public Commands.NavigationCommands.NavBarSelectCommand NavBarSelectCommand { get; private set; }

        public AppVM()
        {
            // Deserialise data and add it to a PartList
            serialiser = new Serialiser("Data.xml");
            data = serialiser.Deserialise() 
                ?? throw new InvalidOperationException("Data was not received from serialiser.");
            
            PartList home = new PartList();
            foreach (Part part in data) home.AddItem(part);

            // Display this PartList in the corresponding UserControl
            SimpleList partListView = new();
            PartListVM partListViewModel = new PartListVM(home);
            partListView.DataContext = partListViewModel;
            navigationStack = [new WindowContainer(partListView, partListViewModel.Name)];
            currentUserControl = partListView;

            // Initialise other properties
            NavBarSelectCommand = new(this);
        }

        public void PushWindow(WindowContainer window)
        {
            if (window.WindowReference is null) return;
            navigationStack.Add(window);
            OnPropertyChanged(this, nameof(NavigationStack));
            CurrentUserControl = window.WindowReference;
        }

        public WindowContainer PopWindow()
        {
            WindowContainer poppedItem = navigationStack[^1];
            navigationStack.RemoveAt(navigationStack.Count - 1);
            OnPropertyChanged(this, nameof(NavigationStack));
            CurrentUserControl = navigationStack[^1].WindowReference ?? throw new NullReferenceException("Null reference on navigationStack");
            return poppedItem;
        }

        public void OnClose()
        {
            serialiser.Serialise(data);
        }
    }
}

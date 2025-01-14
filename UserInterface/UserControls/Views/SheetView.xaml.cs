using System.Windows;
using System.Windows.Controls;
using UserInterface.UserControls.ViewModels;

namespace UserInterface.UserControls.Views
{
    /// <summary>
    /// Interaction logic for SheetView.xaml
    /// </summary>
    public partial class SheetView : UserControl
    {
        public SheetView()
        {
            InitializeComponent();
        }

        private void OnQuestionsChanged()
        {
            if (IsLoaded && DataContext is SheetVM sheetVM)
            {
                sheetVM.OnQuestionsChanged();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0 && e.RemovedItems[0] != e.AddedItems[0])
            {
                OnQuestionsChanged();
            }
        }

        private void CheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            OnQuestionsChanged();
        }
    }
}

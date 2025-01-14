using System.Windows;
using System.Windows.Controls;

namespace UserInterface.Popups.Views
{
    /// <summary>
    /// Interaction logic for CourseAddPopup.xaml
    /// </summary>
    public partial class SheetAddPopup : Window
    {
        public SheetAddPopup()
        {
            InitializeComponent();
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            startDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            dueDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            DialogResult = true;
            Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

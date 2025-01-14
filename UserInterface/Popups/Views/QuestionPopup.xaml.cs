using System.Windows;
using System.Windows.Controls;

namespace UserInterface.Popups.Views
{
    /// <summary>
    /// Interaction logic for QuestionPopup.xaml
    /// </summary>
    public partial class QuestionPopup : Window
    {
        public QuestionPopup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int amountToAdd;
            if ((string)button.Content == "+")
            {
                amountToAdd = 1;
            }
            else if ((string)button.Content == "-")
            {
                amountToAdd = -1;
            }
            else throw new InvalidOperationException("Calling button was not recognised");

            textBoxNumQs.Text = (int.Parse(textBoxNumQs.Text) + amountToAdd).ToString();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxNumQs.GetBindingExpression(TextBox.TextProperty).UpdateSource();
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

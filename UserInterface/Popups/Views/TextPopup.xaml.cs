using System.Windows;
using System.Windows.Controls;

namespace UserInterface.Popups.Views
{
    /// <summary>
    /// Interaction logic for TextPopup.xaml
    /// </summary>
    public partial class TextPopup : Window
    {
        public string Prompt
        {
            get { return (string)GetValue(PromptProperty); }
            set { SetValue(PromptProperty, value); }
        }

        public static readonly DependencyProperty PromptProperty =
            DependencyProperty.Register("Prompt", typeof(string), typeof(TextPopup), new PropertyMetadata(""));



        public string InputText
        {
            get { return (string)GetValue(InputTextProperty); }
            set { SetValue(InputTextProperty, value); }
        }

        public static readonly DependencyProperty InputTextProperty =
            DependencyProperty.Register("InputText", typeof(string), typeof(TextPopup), new PropertyMetadata(""));



        public TextPopup()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
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

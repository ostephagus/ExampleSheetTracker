using System.Windows;
using System.Windows.Controls.Primitives;

namespace UserInterface.Popups.Views
{
    /// <summary>
    /// Interaction logic for EnumPopup.xaml
    /// </summary>
    public partial class EnumPopup : Window
    {
        public string Prompt
        {
            get { return (string)GetValue(PromptProperty); }
            set { SetValue(PromptProperty, value); }
        }

        public static readonly DependencyProperty PromptProperty =
            DependencyProperty.Register("Prompt", typeof(string), typeof(EnumPopup), new PropertyMetadata(""));



        public string[] Options
        {
            get { return (string[])GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }

        public static readonly DependencyProperty OptionsProperty =
            DependencyProperty.Register("Options", typeof(string[]), typeof(EnumPopup));



        public string SelectedOption
        {
            get { return (string)GetValue(SelectedOptionProperty); }
            set { SetValue(SelectedOptionProperty, value); }
        }

        public static readonly DependencyProperty SelectedOptionProperty =
            DependencyProperty.Register("SelectedOption", typeof(string), typeof(EnumPopup), new PropertyMetadata(""));

        public EnumPopup()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            inputComboBox.GetBindingExpression(Selector.SelectedItemProperty).UpdateSource();
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

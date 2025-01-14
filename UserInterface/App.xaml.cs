using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Commands.NavigationCommands.ListItemSelectCommand? listItemSelectCommand;

        public void Start(object sender, StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            MainWindow mainWindow = new MainWindow();
            AppVM appVM = new AppVM();
            mainWindow.DataContext = appVM;
            mainWindow.Show();
            listItemSelectCommand = new(appVM);
        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            listItemSelectCommand?.Execute(sender);
        }
    }

}

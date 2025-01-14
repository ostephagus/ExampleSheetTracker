using System.Windows.Controls;

namespace UserInterface
{
    public class WindowContainer
    {
        public UserControl? WindowReference { get; set; }
        public string WindowName { get; set; }

        public WindowContainer() : this(null, "") { }

        public WindowContainer(UserControl? windowReference, string windowName)
        {
            WindowReference = windowReference;
            WindowName = windowName;
        }
    }
}

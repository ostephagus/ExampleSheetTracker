using DataManager;
using System.Windows.Controls;
using System.Windows;
using UserInterface.UserControls.ViewModels;
using UserInterface.UserControls.Views;

namespace UserInterface.Commands
{
    public static class NavigationCommands
    {
        /// <summary>
        /// Command to use by the navigation list to change window. Call <see cref="Execute(object?)"/> with a reference to the <see cref="=WindowContainer"> in the parameter
        /// </summary>
        public class NavBarSelectCommand : VMCommandBase<AppVM>
        {
            public NavBarSelectCommand(AppVM vm) : base(vm) { }

            /// <summary>
            /// Function to be called when changing window using the navigation list
            /// </summary>
            /// <param name="parameter">A reference to the underlying <see cref="WindowContainer"/> that was clicked.</param>
            public override void Execute(object? parameter)
            {
                if (parameter is WindowContainer windowContainer)
                {
                    // Pop windows until at the correct view.
                    while (parentViewModel.CurrentUserControl != windowContainer.WindowReference)
                    {
                        parentViewModel.PopWindow();
                    }
                    if (parentViewModel.CurrentUserControl.DataContext is IListViewModel currentUserControlVM)
                    {
                        currentUserControlVM.OnItemsChanged();
                    }
                }
                else throw new ArgumentException("The parameter to this command must be a WindowContainer");
            }
        }

        public class ListItemSelectCommand : VMCommandBase<AppVM>
        {
            public ListItemSelectCommand(AppVM vm) : base(vm) { }

            /// <summary>
            /// Function to be called when changing window using an item button in a <see cref="ListView"/>
            /// </summary>
            /// <param name="parameter">A reference to the <see cref="Button"/> that was clicked.</param>
            public override void Execute(object? parameter)
            {
                if (parameter is ListViewItem clickedItem)
                {
                    if (clickedItem.Content is Part part)
                    {
                        SimpleList partView = new SimpleList();
                        PartVM partViewModel = new PartVM(part);
                        partView.DataContext = partViewModel;
                        parentViewModel.PushWindow(new WindowContainer(partView, partViewModel.Name));
                    }
                    else if (clickedItem.Content is Term term)
                    {
                        TermView termView = new TermView();
                        TermVM termViewModel = new TermVM(term);
                        termView.DataContext = termViewModel;
                        parentViewModel.PushWindow(new WindowContainer(termView, termViewModel.Name));
                    }
                    else if (clickedItem.Content is Course course)
                    {
                        CourseView courseView = new CourseView();
                        CourseVM courseViewModel = new CourseVM(course);
                        courseView.DataContext = courseViewModel;
                        parentViewModel.PushWindow(new WindowContainer(courseView, courseViewModel.Name));
                    }
                    else if (clickedItem.Content is Sheet sheet)
                    {
                        SheetView sheetView = new SheetView();
                        SheetVM sheetViewModel = new SheetVM(sheet);
                        sheetView.DataContext = sheetViewModel;
                        parentViewModel.PushWindow(new WindowContainer(sheetView, sheetViewModel.Name));
                    }
                    else if (clickedItem.Content is WindowContainer)
                    {
                        NavBarSelectCommand navBarSelectCommand = new NavBarSelectCommand(parentViewModel);
                        navBarSelectCommand.Execute(clickedItem.Content);
                    }
                    else if (clickedItem.Content is Question)
                    {
                        // Do nothing - maybe useful for timers if added.
                    }
                    else
                    {
                        MessageBox.Show("Case not added.");
                    }
                }
                else throw new ArgumentException("ListItemSelectCommand must have a reference to the clicked ListViewItem object as the parameter");
            }
        }
    }
}

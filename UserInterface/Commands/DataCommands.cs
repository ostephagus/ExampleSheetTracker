using DataManager;
using UserInterface.Popups.ViewModels;
using UserInterface.Popups.Views;
using UserInterface.UserControls.ViewModels;
using UserInterface.UserControls.Views;

namespace UserInterface.Commands
{
    public static class DataCommands
    {
        public class EditCourseName : VMCommandBase<TermVM>
        {
            public EditCourseName(TermVM parentVM) : base(parentVM) { }

            public override void Execute(object? parameter)
            {
                if (parameter is Course course)
                {
                    TextPopup textPopup = new TextPopup();
                    textPopup.Title = "Edit course name";
                    textPopup.Prompt = "Course name";
                    textPopup.InputText = course.Name;
                    textPopup.ShowDialog();
                    course.SetName(textPopup.InputText);
                    parentViewModel.OnItemsChanged();
                }
            }
        }

        public class AddCourse : VMCommandBase<TermVM>
        {
            public AddCourse(TermVM parentViewModel) : base(parentViewModel) { }

            public override void Execute(object? parameter)
            {
                TextPopup textPopup = new TextPopup();
                textPopup.Title = "Add new course";
                textPopup.Prompt = "Course name";
                if (textPopup.ShowDialog() == true)
                {
                    parentViewModel.Items?.Add(new Course(textPopup.InputText, new List<Sheet>()));
                    parentViewModel.OnItemsChanged();
                }
            }
        }

        public class AddSheet : VMCommandBase<CourseVM>
        {
            public AddSheet(CourseVM parentViewModel) : base(parentViewModel) { }

            public override void Execute(object? parameter)
            {
                SheetAddPopup popup = new SheetAddPopup();
                Sheet sheetToAdd = new Sheet(DateOnly.FromDateTime(DateTime.Today), DateOnly.FromDateTime(DateTime.Today).AddDays(14), (parentViewModel.Items?.Count ?? 0) + 1);
                SheetPopupVM popupVM;
                if (parentViewModel.Items is not null && parentViewModel.Items.Count > 0)
                {
                    popupVM = new SheetPopupVM(sheetToAdd, parentViewModel.Items[^1]);
                }
                else
                {
                    popupVM = new SheetPopupVM(sheetToAdd);
                }
                popup.DataContext = popupVM;
                if (popup.ShowDialog() == true)
                {
                    parentViewModel.Items?.Add(sheetToAdd);
                    parentViewModel.OnItemsChanged();
                }
            }
        }

        public class AddTerm : VMCommandBase<PartVM>
        {
            public AddTerm(PartVM parentViewModel) : base(parentViewModel) { }

            public override bool CanExecute(object? parameter)
            {
                return parentViewModel.Items?.Count < 3;
            }

            public override void Execute(object? parameter)
            {
                EnumPopup popup = new EnumPopup();
                
                popup.Options = Enum.GetNames(typeof(TermName));
                popup.Prompt = "Select term to add";
                
                if (popup.Options is not null && popup.Options.Length > 0)
                {
                    popup.SelectedOption = popup.Options[0];
                }

                if (popup.ShowDialog() == true)
                {
                    parentViewModel.Items?.Add(new Term((TermName)Enum.Parse(typeof(TermName), popup.SelectedOption)));
                    parentViewModel.OnItemsChanged();
                }
            }
        }

        public class AddPart : VMCommandBase<PartListVM>
        {
            public AddPart(PartListVM parentViewModel) : base(parentViewModel) { }

            public override void Execute(object? parameter)
            {
                EnumPopup popup = new EnumPopup();

                popup.Options = Enum.GetNames(typeof(PartName));
                popup.Prompt = "Select part to add";
                
                if (popup.Options is not null && popup.Options.Length > 0)
                {
                    popup.SelectedOption = popup.Options[0];
                }

                if (popup.ShowDialog() == true)
                {
                    
                    parentViewModel.Items?.Add(new Part((PartName)Enum.Parse(typeof(PartName), popup.SelectedOption)));
                    
                    parentViewModel.OnItemsChanged();
                }
            }
        }

        public class EditSheet : VMCommandBase<SheetVM>
        {
            public EditSheet(SheetVM parentViewModel) : base(parentViewModel) { }

            public override bool CanExecute(object? parameter)
            {
                return parentViewModel.UnderlyingClass is not null;
            }

            public override void Execute(object? parameter)
            {
                SheetAddPopup popup = new SheetAddPopup();
                if (parentViewModel.UnderlyingClass is null) throw new InvalidOperationException("CanExecute must be checked before this command is executed.");
                SheetPopupVM popupVM = new SheetPopupVM(parentViewModel.UnderlyingClass);
                popup.DataContext = popupVM;
                popup.ShowDialog();
                parentViewModel.OnDatesChanged();
            }
        }

        public class SetSheetDates : VMCommandBase<SheetPopupVM>
        {
            public SetSheetDates(SheetPopupVM parentViewModel) : base(parentViewModel) { }

            public override bool CanExecute(object? parameter) => !parentViewModel.IsFirst;

            public override void Execute(object? parameter)
            {
                if (parentViewModel.PreviousSheet is null) throw new InvalidOperationException("CanExecute must be checked before this command is executed.");
                Sheet previousSheet = parentViewModel.PreviousSheet; // Not null when CanExecute is true.
                parentViewModel.StartDate = previousSheet.DueDate.ToDateTime(new TimeOnly());
                parentViewModel.DueDate = parentViewModel.StartDate.AddDays(14);
                parentViewModel.OnDatesChanged();
            }
        }

        public class AddQuestions : VMCommandBase<SheetVM>
        {
            public AddQuestions(SheetVM parentViewModel) : base(parentViewModel) { }

            public override bool CanExecute(object? parameter)
            {
                return parentViewModel.UnderlyingClass is not null;
            }

            public override void Execute(object? parameter)
            {
                QuestionPopup popup = new QuestionPopup();
                if (parentViewModel.UnderlyingClass is null) throw new InvalidOperationException("CanExecute must be checked before this command is executed.");
                QuestionPopupVM popupVM = new QuestionPopupVM(parentViewModel.UnderlyingClass);
                popup.DataContext = popupVM;
                popup.ShowDialog();
                parentViewModel.OnQuestionsChanged();
            }
        }
    }
}

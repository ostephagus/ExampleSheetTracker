using DataManager;

namespace UserInterface.UserControls.ViewModels
{
    public class TermVM : SimpleListVM<Term, Course>
    {
        public Commands.DataCommands.EditCourseName EditCourseName { get; set; }

        public Commands.DataCommands.AddCourse AddCourse { get; set; }

        public TermVM(Term underlyingClass)
        {
            this.underlyingClass = underlyingClass;
            EditCourseName = new Commands.DataCommands.EditCourseName(this);
            AddCourse = new Commands.DataCommands.AddCourse(this);
        }
    }
}

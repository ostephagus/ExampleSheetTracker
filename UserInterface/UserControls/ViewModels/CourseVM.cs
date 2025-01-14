using DataManager;

namespace UserInterface.UserControls.ViewModels
{
    public class CourseVM : SimpleListVM<Course, Sheet>
    {
        public Commands.DataCommands.AddSheet AddSheet { get; private set; }

        public CourseVM(Course underlyingClass) : base(underlyingClass)
        {
            AddSheet = new Commands.DataCommands.AddSheet(this);
        }

    }
}

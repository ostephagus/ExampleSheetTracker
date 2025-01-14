using DataManager;
using UserInterface.Commands;

namespace UserInterface.UserControls.ViewModels
{
    public class PartVM : SimpleListVM<Part, Term>
    {
        public DataCommands.AddTerm AddItemCommand { get; private set; }

        public PartVM(Part? underlyingClass) : base(underlyingClass)
        {
            AddItemCommand = new DataCommands.AddTerm(this);
        }

        public PartVM() : this(null) { }
    }
}

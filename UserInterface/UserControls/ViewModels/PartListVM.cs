using DataManager;
using UserInterface.Commands;

namespace UserInterface.UserControls.ViewModels
{
    public class PartListVM : SimpleListVM<PartList, Part>
    {
        public DataCommands.AddPart AddItemCommand { get; private set; }

        public PartListVM(PartList? underlyingClass) : base(underlyingClass)
        {
            AddItemCommand = new DataCommands.AddPart(this);
        }

        public PartListVM() : this(null) { }
    }
}

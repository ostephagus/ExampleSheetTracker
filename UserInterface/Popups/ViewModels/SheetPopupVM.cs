using DataManager;
using UserInterface.Commands;

namespace UserInterface.Popups.ViewModels
{
    public class SheetPopupVM : ViewModelBase
    {
        private Sheet underlyingSheet;
        private Sheet? previousSheet;

        public DateTime StartDate { get => (underlyingSheet.StartDate).ToDateTime(TimeOnly.MinValue); set => underlyingSheet.StartDate = DateOnly.FromDateTime(value); }
        public DateTime DueDate { get => (underlyingSheet.DueDate).ToDateTime(TimeOnly.MinValue); set => underlyingSheet.DueDate = DateOnly.FromDateTime(value); }
        public bool IsFirst { get => previousSheet is null; }
        public Sheet UnderlyingSheet { get => underlyingSheet; }
        public Sheet? PreviousSheet { get => previousSheet; }
        public DataCommands.SetSheetDates SetSheetDates { get; set; }

        public SheetPopupVM(Sheet underlyingSheet, Sheet? previousSheet)
        {
            this.underlyingSheet = underlyingSheet;
            this.previousSheet = previousSheet;
            SetSheetDates = new DataCommands.SetSheetDates(this);
        }

        public SheetPopupVM(Sheet underlyingSheet) : this(underlyingSheet, null) { }

        public SheetPopupVM() : this(new Sheet()) { }

        public void OnDatesChanged()
        {
            OnPropertyChanged(this, nameof(StartDate));
            OnPropertyChanged(this, nameof(DueDate));
        }
    }
}

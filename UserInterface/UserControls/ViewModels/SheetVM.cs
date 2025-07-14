using DataManager;
using UserInterface.Commands;
using UserInterface.Converters;

namespace UserInterface.UserControls.ViewModels
{
    public class SheetVM : SimpleListVM<Sheet, Question>
    {
        private DoubleToPercentage percentageConverter = new DoubleToPercentage();

        private readonly DateOnly TODAY = DateOnly.FromDateTime(DateTime.Today);

        public Array ProgressOptions { get => Enum.GetValues(typeof(Progress)); }
        public string[] DoingOptions { get => Enum.GetNames(typeof(TriState)); }

        public double ProgressMaybe { get => underlyingClass?.GetProgress(true) ?? 0; }
        public double Progress { get => underlyingClass?.GetProgress(false) ?? 0; }
        public int? DaysAhead { get => underlyingClass?.GetDaysAhead(); }
        public string ExpectedProgress { get => GetExpectedProgressStr(); }
        public DateOnly StartDate { get => underlyingClass?.StartDate ?? TODAY; }
        public DateOnly DueDate { get => underlyingClass?.DueDate ?? TODAY; }

        public Sheet? UnderlyingClass { get => underlyingClass; }

        public DataCommands.EditSheet EditSheetCommand { get; private set; }

        public DataCommands.AddQuestions AddQuestionsCommand { get; private set; }

        public SheetVM(Sheet underlyingClass) : base(underlyingClass)
        {
            EditSheetCommand = new DataCommands.EditSheet(this);
            AddQuestionsCommand = new DataCommands.AddQuestions(this);
        }

        private string GetExpectedProgressStr()
        {
            double proportionOfTime = (TODAY.DayNumber - StartDate.DayNumber) / (double)(DueDate.DayNumber - StartDate.DayNumber);
            if (proportionOfTime > 1)
            {
                proportionOfTime = 1;
            }
            else if (proportionOfTime < 0)
            {
                proportionOfTime = 0;
            }

            return $"(expected {(int)(proportionOfTime * 100)}%)";
        }

        public void OnQuestionsChanged()
        {
            OnPropertyChanged(this, nameof(Items));
            OnPropertyChanged(this, nameof(ProgressMaybe));
            OnPropertyChanged(this, nameof(Progress));
            OnPropertyChanged(this, nameof(DaysAhead));
        }

        public void OnDatesChanged()
        {
            OnPropertyChanged(this, nameof(StartDate));
            OnPropertyChanged(this, nameof(DueDate));
            OnPropertyChanged(this, nameof(ExpectedProgress));
            OnPropertyChanged(this, nameof(DaysAhead));
        }
    }
}

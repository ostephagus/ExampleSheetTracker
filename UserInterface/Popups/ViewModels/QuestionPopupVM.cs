using DataManager;

namespace UserInterface.Popups.ViewModels
{
    class QuestionPopupVM : ViewModelBase
    {
        private Sheet underlyingClass;

        public int NumberOfQuestions { get => underlyingClass.List.Count; set => AddOrRemoveQuestions(value); }

        public QuestionPopupVM(Sheet underlyingClass)
        {
            this.underlyingClass = underlyingClass;
        }

        public void AddOrRemoveQuestions(int newCount)
        {
            while (newCount > underlyingClass.List.Count)
            {
                underlyingClass.List.Add(new Question(underlyingClass.List.Count + 1)); // Add questions until there is enough
            }

            while (newCount < underlyingClass.List.Count)
            {
                underlyingClass.List.RemoveAt(underlyingClass.List.Count - 1); // Or remove the last question until there is the right amount
            }
        }
    }
}

using System.Xml.Serialization;

namespace DataManager
{
    public class Sheet : NamedList<Question>
    {
        private DateOnly startDate;
        private DateOnly dueDate;
        private int number;

        [XmlIgnore]
        public DateOnly StartDate { get => startDate; set => startDate = value; }

        [XmlElement(ElementName = "StartDate")]
        public string StartDateStr { get => StartDate.ToString(); set => startDate = DateOnly.Parse(value); }
        [XmlIgnore]
        public DateOnly DueDate { get => dueDate; set => dueDate = value; }

        [XmlElement(ElementName = "DueDate")]
        public string DueDateStr { get => DueDate.ToString(); set => dueDate = DateOnly.Parse(value); }

        [XmlAttribute]
        public int Number { get => number; set => number = value; }

        [XmlIgnore]
        public override string Name { get => $"Sheet {number}"; }

        [XmlIgnore]
        public bool IsCurrent { get => CheckIsCurrent(); }

        public Sheet(List<Question> questions, DateOnly startDate, DateOnly dueDate, int number) : base(questions)
        {
            this.startDate = startDate;
            this.dueDate = dueDate;
            this.number = number;
        }
        public Sheet(DateOnly startDate, DateOnly dueDate, int number) : this(new List<Question>(), startDate, dueDate, number) { }
        public Sheet() : base() { }

        public override void AddItem(Question question)
        {
            list.Add(question);
            list.Sort(new Comparison<Question>((q1, q2) => q1.Number - q2.Number));
        }
        public override void RemoveItem(int number)
        {
            list.RemoveAt(number);
        }

        public bool CheckIsCurrent()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            return today > startDate && today < dueDate;
        }

        private double GetQuestionProgress(Question question)
        {
            return question.Progress switch
            {
                Progress.ThoughtAbout => 0.1,
                Progress.InProgress => 0.5,
                Progress.ToWriteUp => 0.9,
                Progress.Finished => 1,
                _ => 0
            };
        }

        /// <summary>
        /// Gets the progress of the sheet, with or without questions that are marked <see cref="TriState.Maybe"/>
        /// </summary>
        /// <param name="includeMaybe">Whether to include questions that are marked <see cref="TriState.Maybe"/></param>
        /// <returns>A value between 0 and 1 indicating the progress.</returns>
        public double GetProgress(bool includeMaybe)
        {
            double progressTotal = 0;
            int questionsCounted = 0;
            foreach (Question question in list)
            {
                if (question.Doing == TriState.Yes || (question.Doing == TriState.Maybe && includeMaybe))
                {
                    progressTotal += GetQuestionProgress(question);
                    questionsCounted++;
                }
            }
            if (questionsCounted == 0) return 0;

            else return progressTotal / questionsCounted;
        }

        public int GetDaysAhead()
        {
            if (!IsCurrent) return 0;

            double progress = GetProgress(false);
            double proportionOfTime = (DateOnly.FromDateTime(DateTime.Today).DayNumber - StartDate.DayNumber) / (double)(DueDate.DayNumber - StartDate.DayNumber);

            double daysAhead = progress - proportionOfTime;
            return (int)Math.Round(daysAhead * (double)(DueDate.DayNumber - StartDate.DayNumber));
        }
    }
}

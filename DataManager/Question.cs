using System.Xml.Serialization;

namespace DataManager
{
    public enum Progress
    {
        NotStarted,
        ThoughtAbout,
        InProgress,
        ToWriteUp,
        Finished
    }

    public enum TriState
    {
        No,
        Maybe,
        Yes
    }

    /// <summary>
    /// Class to represent individual questions on an example sheet
    /// </summary>
    public class Question : NamedItem
    {
        private int number;
        private bool starred;
        private Progress progress;
        private TriState doing;
        private TimeSpan timeTaken;

        [XmlAttribute]
        public int Number { get => number; set => number = value; }
        public bool Starred { get => starred; set => starred = value; }
        public Progress Progress { get => progress; set => progress = value; }
        public TriState Doing { get => doing; set => doing = value; }
        public TimeSpan TimeTaken { get => timeTaken; set => timeTaken = value; }

        [XmlIgnore]
        public override string Name { get => $"Q{number}"; }

        public Question(int number, bool starred, Progress progress, TriState doing, TimeSpan timeTaken)
        {
            this.number = number;
            this.starred = starred;
            this.progress = progress;
            this.doing = doing;
            this.timeTaken = timeTaken;
        }

        public Question(int number, bool starred, Progress progress, TriState doing) : this(number, starred, progress, doing, TimeSpan.Zero) { }

        public Question(int number) : this(number, false, Progress.NotStarted, TriState.Yes) { }

        public Question() : this(1) { }
    }
}

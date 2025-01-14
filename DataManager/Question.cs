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

        [XmlAttribute]
        public int Number { get => number; set => number = value; }
        public bool Starred { get => starred; set => starred = value; }
        public Progress Progress { get => progress; set => progress = value; }
        public TriState Doing { get => doing; set => doing = value; }

        [XmlIgnore]
        public override string Name { get => $"Q{number}"; }

        public Question(int number, bool starred, Progress progress, TriState doing)
        {
            this.number = number;
            this.starred = starred;
            this.progress = progress;
            this.doing = doing;
        }

        public Question(int number) : this(number, false, Progress.NotStarted, TriState.Yes) { }

        public Question() : this(1) { }
    }
}

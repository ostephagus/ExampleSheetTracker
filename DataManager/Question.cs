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
        private string name;
        private bool starred;
        private Progress progress;
        private TriState doing;

        [XmlAttribute]
        public override string Name { get => name; set => name = value; }
        public bool Starred { get => starred; set => starred = value; }
        public Progress Progress { get => progress; set => progress = value; }
        public TriState Doing { get => doing; set => doing = value; }


        public Question(string number, bool starred, Progress progress, TriState doing)
        {
            this.name = number;
            this.starred = starred;
            this.progress = progress;
            this.doing = doing;
        }

        public Question(string number) : this(number, false, Progress.NotStarted, TriState.Yes) { }

        public Question() : this("1") { }

        public void Rename(string newName)
        {
            name = newName;
        }
    }
}

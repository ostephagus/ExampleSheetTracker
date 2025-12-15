using System.Xml.Serialization;

namespace DataManager
{
    public enum TermName
    {
        Michaelmas,
        Lent,
        Easter
    }

    public class Term : NamedList<Course>
    {
        private TermName termName;

        [XmlAttribute]
        public TermName TermName { get => termName; set => termName = value; }

        [XmlIgnore]
        public override string Name { get => termName.ToString(); set => Enum.Parse(typeof(TermName), value); }

        public Term(TermName termName, List<Course> courses) : base(courses)
        {
            this.termName = termName;
        }
        public Term(TermName termName) : this(termName, new List<Course>()) { }
        public Term() : base() { }

        public override void AddItem(Course course)
        {
            list.Add(course);
            list.Sort((course1, course2) => string.Compare(course1.Name, course2.Name));
        }

        public override void RemoveItem(int number)
        {
            list.RemoveAt(number);
        }
    }
}

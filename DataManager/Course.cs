using System.Xml.Serialization;

namespace DataManager
{
    public class Course : NamedList<Sheet>
    {
        private string name;

        [XmlIgnore]
        public override string Name { get => name; }

        [XmlAttribute("CourseName")]
        public string SerialisationName { get => name; set => name = value; }

        [XmlIgnore]
        public int DaysAhead { get => GetDaysAhead(); }

        public Course(string name, List<Sheet> sheets) : base(sheets)
        {
            this.name = name;
        }

        public Course(string name) : this(name, new List<Sheet>()) { }

        public Course() : this("") { }

        public void SetName(string newName)
        {
            name = newName;
        }

        public override void AddItem(Sheet sheet)
        {
            list.Add(sheet);
            list.Sort((sheet1, sheet2) => sheet1.Number - sheet2.Number);
        }

        public override void RemoveItem(int number)
        {
            list.RemoveAt(number);
        }

        public int GetDaysAhead()
        {
            foreach(Sheet sheet in list)
            {
                if (sheet.IsCurrent)
                {
                    return sheet.GetDaysAhead();
                }
            }
            return 0;
        }
    }
}

using System.Xml.Serialization;

namespace DataManager
{
    public enum PartName
    {
        IA,
        IB,
        II,
        III
    }

    public class Part : NamedList<Term>
    {
        private PartName partName;

        [XmlAttribute]
        public PartName PartName { get => partName; set => partName = value; }

        [XmlIgnore]
        public override string Name { get => partName.ToString(); }

        public Part(PartName partName, List<Term> terms) : base(terms)
        {
            this.partName = partName;
        }
        public Part(PartName partName) : this(partName, new List<Term>()) { }
        public Part() : base() { }

        public override void AddItem(Term term)
        {
            list.Add(term);
            list.Sort((term1, term2) => (int)term1.TermName - (int)term2.TermName);
        }

        public override void RemoveItem(int number)
        {
            list.RemoveAt(number);
        }
    }
}

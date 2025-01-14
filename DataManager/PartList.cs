namespace DataManager
{
    public class PartList : NamedList<Part>
    {
        public override string Name => "home";

        public override void AddItem(Part part)
        {
            list.Add(part);
            list.Sort((part1, part2) => (int)part1.PartName - (int)part2.PartName);
        }

        public override void RemoveItem(int number)
        {
            list.RemoveAt(number);
        }
    }
}

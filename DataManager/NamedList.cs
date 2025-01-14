namespace DataManager
{
    public abstract class NamedList<T> : NamedItem where T : NamedItem
    {
        protected List<T> list;

        public List<T> List { get => list; }

        public NamedList()
        {
            list = new List<T>();
        }

        public NamedList(List<T> list)
        {
            this.list = list;
        }


        /// <summary>
        /// Adds an item to the list and sorts it
        /// </summary>
        /// <param name="item">The item to add to the list</param>
        public abstract void AddItem(T item);

        /// <summary>
        /// Removes an item from the list
        /// </summary>
        /// <param name="number">The position of the item in the list</param>
        public abstract void RemoveItem(int number);
    }
}

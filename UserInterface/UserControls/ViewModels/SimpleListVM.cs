using DataManager;
using System.ComponentModel;

namespace UserInterface.UserControls.ViewModels
{
    /// <summary>
    /// ViewModel for Part and Term Views, that are both very similar. Can (and should) be inherited for more complex lists.
    /// </summary>
    public abstract class SimpleListVM<Type, ItemType> : ViewModelBase, IListViewModel where Type : NamedList<ItemType> where ItemType : NamedItem, new()
    {
        protected Type? underlyingClass;

        public string Name { get => underlyingClass?.Name ?? ""; }
        public BindingList<ItemType>? Items { get => new BindingList<ItemType>(underlyingClass?.List ?? new List<ItemType>()); }

        public SimpleListVM(Type? underlyingClass)
        {
            this.underlyingClass = underlyingClass;
        }

        public SimpleListVM() : this(null) { }

        public void OnItemsChanged()
        {
            OnPropertyChanged(this, nameof(Items));
        }
    }
}

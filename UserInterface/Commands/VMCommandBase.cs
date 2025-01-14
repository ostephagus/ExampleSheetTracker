using System.Windows.Input;

namespace UserInterface.Commands
{
    /// <summary>
    /// Base class for commands that are related to a specific ViewModel using dependency injection. Abstractly implements <see cref="ICommand"/>.
    /// </summary>
    /// <typeparam name="VMType">The type of the ViewModel that will be used with the Command.</typeparam>
    public abstract class VMCommandBase<VMType> : ICommand
    {
        protected VMType parentViewModel;

        public event EventHandler? CanExecuteChanged;

        public virtual void OnCanExecuteChanged(object? sender, EventArgs e)
        {
            CanExecuteChanged?.Invoke(sender, e);
        }

        public virtual bool CanExecute(object? parameter) { return true; }

        public abstract void Execute(object? parameter);

        public VMCommandBase(VMType parentViewModel)
        {
            this.parentViewModel = parentViewModel;
        }
    }
}

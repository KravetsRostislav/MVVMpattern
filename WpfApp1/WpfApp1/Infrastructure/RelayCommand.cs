using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.Models
{
    class RelayCommand : ICommand
    {
        public Action<object> action;
        public Func<object,bool> predicate;

        public RelayCommand(Action<object> action, Func<object, bool> predicate = null)
        {
            this.action = action;
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
             return predicate?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            action?.Invoke(parameter);
        }
    }
}

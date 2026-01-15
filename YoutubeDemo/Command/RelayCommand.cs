using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeDemo.Command
{
    public class RelayCommand : ICommand
    {
        


        public event EventHandler CanExecuteChanged;
        Action callback;
        public RelayCommand(Action callback)
        {
            this.callback = callback;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.callback.Invoke();
        }
    }
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;  // 要執行的動作
        private readonly Func<T, bool> _canExecute;  // 能否執行（可選）

        public RelayCommand(Action<T> execute)
        {
            _execute = execute;
           
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke((T)parameter);
        }
    }

    
}

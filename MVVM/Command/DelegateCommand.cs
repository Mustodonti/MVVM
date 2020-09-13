using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MVVM
{
    public class DelegateCommand : ICommand
    {
        Action<object> execute; //Создадим событие
        Func<object, bool> canExecute;//Функция принимает обьект и возвращает логическое выражение
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }//Вызов обновления команды CanExecuteChanged делается через  CommandManager подписываясь в RequerySuggested
            remove { CommandManager.RequerySuggested -= value; }//Отписываемся, чтобы утечек не было
        }

        public bool CanExecute(object parameter)//Возвращает, можно ли выполнить команду или нет
        {
            if (canExecute != null)
                return canExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }
        public DelegateCommand(Action<object> executeAction) : this(executeAction, null)
        {
            execute = executeAction;
        }
        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            canExecute = canExecuteFunc;
            execute = executeAction;
        }
    }
}

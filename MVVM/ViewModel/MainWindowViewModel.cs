using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged //DependencyObject - готовый класс
    {
        Book[] books;
        Book selectedbook;
        public ObservableCollection <Book> Books { get; private set; }
        public Book SelectedBook
        {
            get { return selectedbook; }
            set
            {
                selectedbook = value;
                OnPropertyChanged("SelectedBook");
            }
        }
        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public MainWindowViewModel()
        {
            Books =new ObservableCollection<Book> (Book.GetBooks());
            AddCommand = new DelegateCommand(AddBook);
            RemoveCommand = new DelegateCommand(RemoveBook, CanRemoveBook);
        }

        private bool CanRemoveBook(object arg)
        {
            return (arg as Book) != null;
        }

        private void RemoveBook(object obj)
        {
            Books.Remove((Book)obj);
        }

        private void AddBook(object obj)
        {
            Books.Add(new Book {Author = "Автор", Title="Книга" });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}

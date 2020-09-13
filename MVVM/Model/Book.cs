using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace MVVM
{
    public class Book : INotifyPropertyChanged //INotifyCollectionChanged - для коллекции
    {
        string author;
        string title;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public static Book[] GetBooks()
        {
            var result = new[]
            {
                new Book() {Author = "Лев", Title = "Война"},
                new Book() {Author = "Грига", Title = "Дикий вест"},
                new Book() {Author = "Жора", Title = "Дон хуфн"}
            };
            return result;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}

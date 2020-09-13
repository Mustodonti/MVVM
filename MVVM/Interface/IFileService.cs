using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM.Interface
{
    /// <summary>
    ///  Open - метод предназначен для открытия файла. Он принимает путь к файлу и возвращает список объектов
    ///  Save - сохраняет данные из списка в файле по определенному пути.
    /// </summary>
    interface IFileService
    {
        List<Book> Open(string filename);
        void Save(string filename, List<Book> phonesList);
    }
}

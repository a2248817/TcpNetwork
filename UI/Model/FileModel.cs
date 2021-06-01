using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{

    public class FileModel
    {
        public static ObservableCollection<FileModel> fileModels = Data();

        private static ObservableCollection<FileModel> Data()
        {
            ObservableCollection<FileModel> files = new ObservableCollection<FileModel>();
            FileModel file = new FileModel("本機", "1234567890.txt", 123456789);
            files.Add(file);
            file = new FileModel("遠端", "ABCDEFGHIJ.txt", 12345678);
            files.Add(file);
            file = new FileModel("本機", "一二三四五.txt", 1234567);
            files.Add(file);
            return files;
        }
        public string Source { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        public FileModel(string Source, string Name, long Size)
        {
            this.Source = Source;
            this.Name = Name;
            this.Size = Size;
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;

namespace MultiCodes.ViewModels
{
    public class FileBar : INotifyPropertyChanged
    {
        static FileBar _instance;
        public static FileBar Instance
        {
            get
            {
                if (_instance == null) _instance = new FileBar();
                return _instance;
            }
        }

        ItemNode _rootFileTree;

        public event PropertyChangedEventHandler PropertyChanged;

        public ItemNode RootFileTree
        {
            get { return _rootFileTree; }
            set
            {
                _rootFileTree = value; OnPropertyChanged(nameof(RootFileTree));
            }
        }

        public FileBar()
        {
            _instance = this;

            var fileManager = new Bridge.FileManagerBridge();
            var tree = fileManager.createProjectTree("C:\\Users\\LENOVO\\Desktop\\MultiCodes");
            _rootFileTree = tree;
            OnPropertyChanged(nameof(RootFileTree));
        }
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCodes.Lib.Models
{
    public class ItemNode : INotifyPropertyChanged
    {
        string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; OnPropertyChanged(nameof(Path)); }
        }
        string _name;
        public string Name {
            get {  return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        bool _isDirectory;
        public bool IsDirectory
        {
            get { return _isDirectory; }
            set { _isDirectory = value; OnPropertyChanged(nameof(IsDirectory));}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<ItemNode> _children = new ObservableCollection<ItemNode>();
        public ObservableCollection<ItemNode> Children
        {
            get { return _children; }
            set { _children = value; OnPropertyChanged(nameof(Children)); }
        }

        public ItemNode(string path, string name)
        {
            _path = path;
            _name = name;
        }

        ItemNode _parent;
        public ItemNode Parent
        {
            get { return _parent; }
            set { _parent = value; OnPropertyChanged(nameof(Parent)); }
        }

        public void SetParent(ItemNode parent)
        {
            _parent = parent;
        }
        public void AddChild(ItemNode item)
        {
            Children.Add(item);
            OnPropertyChanged(nameof(Children));
        }

        public void SetIsDirectory()
        {
            _isDirectory = true;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

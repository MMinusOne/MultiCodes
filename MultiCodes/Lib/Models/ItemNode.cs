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
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

                OnPropertyChanged(nameof(Name));
            }
        }
        ItemType _itemNodeType;
        public ItemType ItemNodeType
        {
            get { return _itemNodeType; }
            set { _itemNodeType = value; OnPropertyChanged(nameof(ItemNodeType)); }
        }
        bool _isDirectory = false;
        public bool IsDirectory
        {
            get { return _isDirectory; }
            set
            {
                _isDirectory = value;
                if (_isDirectory == true) ItemNodeType = ItemType.Folder;
                OnPropertyChanged(nameof(IsDirectory));
            }
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
            MakeType(name);
        }

        void MakeType(string name)
        {
            if (name.EndsWith(".js"))
            {
                ItemNodeType = ItemType.JavaScript;
            }
            else if (name.EndsWith(".ts"))
            {
                ItemNodeType = ItemType.TypeScript;
            }
            else if (name.EndsWith(".html"))
            {
                ItemNodeType = ItemType.HTML;
            }
            else if(name.EndsWith(".css"))
            {
                ItemNodeType = ItemType.CSS;
            }
            else if (name.EndsWith(".r"))
            {
                ItemNodeType = ItemType.R;
            }
            else if (name.EndsWith(".rs"))
            {
                ItemNodeType = ItemType.Rust;
            }
            else if (name.EndsWith(".py"))
            {
                ItemNodeType = ItemType.Python;
            }
            else if (name.EndsWith(".c"))
            {
                ItemNodeType = ItemType.C;
            }
            else if (name.EndsWith(".cpp"))
            {
                ItemNodeType = ItemType.Cpp;
            }
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

    public enum ItemType
    {
        JavaScript,
        TypeScript,
        CSharp,
        Rust,
        Cpp,
        C,
        Python,
        Swift,
        R,
        HTML,
        CSS,
        Folder,
    }
}

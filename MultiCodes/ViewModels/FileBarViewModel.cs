using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;
using MultiCodes.Lib;
using MultiCodes.Lib.Models;

namespace MultiCodes.ViewModels
{
    public class FileBarViewModel : INotifyPropertyChanged
    {
        static FileBarViewModel _instance;
        public static FileBarViewModel Instance
        {
            get
            {
                if (_instance == null) _instance = new FileBarViewModel();
                return _instance;
            }
        }

        ItemNode _rootFileTree = new ItemNode("root", "root");

        public event PropertyChangedEventHandler PropertyChanged;

        public ItemNode RootFileTree
        {
            get { return _rootFileTree; }
            set
            {
                _rootFileTree = value; OnPropertyChanged(nameof(RootFileTree));
            }
        }

        FileManagerBridge fileManager = new Bridge.FileManagerBridge();
        public FileBarViewModel()
        {
            _instance = this;
        }

        ItemNode _selectedItemNode;
        public ItemNode SelectedItemNode
        {
            get => _selectedItemNode;
            set
            {
                _selectedItemNode = value;
                if (value != null)
                {
                    if (OnNewCallback != null && !value.IsDirectory)
                    {
                        var textContent = fileManager.readFile(value.Path);
                        OnNewCallback(textContent);
                    }
                }
                    OnPropertyChanged(nameof(SelectedItemNode));
            }
        }
        public void LoadProject(string path)
        {

            RootFileTree = new Lib.Models.ItemNode(path, path);
            var treeBridge = fileManager.createProjectTree(path);
            PopulateBridgeTreeToModel(treeBridge, _rootFileTree);
        }

        void PopulateBridgeTreeToModel(ItemNodeBridge itemNodeBridge, ItemNode itemModel)
        {
            foreach (ItemNodeBridge child in itemNodeBridge.Children)
            {
                    var itemNode = new ItemNode(child.path, child.Name);
                if (child.isDirectory)
                {
                    itemNode.SetIsDirectory();
                    PopulateBridgeTreeToModel(child, itemNode);
                    itemModel.AddChild(itemNode);
                }
                else
                {
                    itemModel.AddChild(itemNode);
                }
                itemNode.SetParent(itemModel);
            }

            OnPropertyChanged(nameof(RootFileTree));
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CreateFile(string name)
        {
            if (SelectedItemNode  == null) return;
            var path = SelectedItemNode.IsDirectory ? SelectedItemNode.Path : SelectedItemNode.Parent.Path;
            fileManager.createFile(path, name);
        }
        public void CreateFolder(string name)
        {
            if (SelectedItemNode  == null) return;
            var path = SelectedItemNode.IsDirectory ? SelectedItemNode.Path : SelectedItemNode.Parent.Path;
            fileManager.createFolder(path, name);
        }

        Predicate<string> OnNewCallback;

        public void OnNew(Predicate<string> onNewCallback)
        {
            OnNewCallback = onNewCallback;
        }

        public void DeletePath(string path)
        {
            if (SelectedItemNode  == null) return;
           
            fileManager.deletePath(path);
        }
    }
}

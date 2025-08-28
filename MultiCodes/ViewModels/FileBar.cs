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

        public FileBar()
        {
            _instance = this;

            var fileManager = new Bridge.FileManagerBridge();
            var treeBridge = fileManager.createProjectTree("C:\\Users\\LENOVO\\Desktop\\MultiCodes");
            PopulateBridgeTreeToModel(treeBridge, _rootFileTree);
        }

        void PopulateBridgeTreeToModel(ItemNodeBridge itemNodeBridge, ItemNode itemModel)
        {
            foreach (ItemNodeBridge child in itemNodeBridge.Children)
            {
                if (child.isDirectory)
                {
                    var itemNode = new ItemNode(child.path, child.Name);
                    PopulateBridgeTreeToModel(child, itemNode);
                    itemModel.AddChild(itemNode);
                }
                else
                {
                    var itemNode = new ItemNode(child.path, child.Name);
                    itemModel.AddChild(itemNode);
                }
            }

            OnPropertyChanged(nameof(RootFileTree));
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

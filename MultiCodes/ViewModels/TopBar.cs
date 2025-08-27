using Bridge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MultiCodes.ViewModels
{
    public class TopBar : INotifyPropertyChanged
    {
        static TopBar _instance;
        public static TopBar Instance
        {
            get
            {
                if (_instance == null) _instance = new TopBar();
                return _instance;
            }
        }

        public TopBar()
        {
            _instance = this;
        }

        ICommand _openProjectCommand;
        public ICommand OpenProjectCommand
        {
            get
            {
                if (_openProjectCommand == null) _openProjectCommand = new RelayCommand(OpenProject, (object obj) => true);
                return _openProjectCommand;
            }
        }

        void OpenProject(object obj)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.ShowDialog();
                var projectTree = new FileManagerBridge().createProjectTree(folderDialog.SelectedPath);
            }
        }

        ICommand _zoomInCommand;
        public ICommand ZoomInCommand
        {
            get
            {
                if (_zoomInCommand == null) _zoomInCommand = new RelayCommand(ZoomIn, (object obj) => true);
                return _zoomInCommand;
            }
        }

        void ZoomIn(object obj)
        {
            CodeEditorViewModel.Instance.FontSize += 1;
        }

        ICommand _zoomOutCommand;
        public ICommand ZoomOutCommand
        {
            get
            {
                if (_zoomOutCommand == null) _zoomOutCommand = new RelayCommand(ZoomOut, (object obj) => true);
                return _zoomOutCommand;
            }
        }

        void ZoomOut(object obj)
        {
            CodeEditorViewModel.Instance.FontSize -= 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

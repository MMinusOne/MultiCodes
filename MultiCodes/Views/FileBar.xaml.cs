using MultiCodes.Lib.Models;
using MultiCodes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiCodes.Views
{
    /// <summary>
    /// Interaction logic for FileBar.xaml
    /// </summary>
    public partial class FileBar : UserControl
    {
        public FileBar()
        {
            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            FileBarViewModel.Instance.SelectedItemNode = (ItemNode)e.NewValue;
        }

        private void MenuItem_CreateFileClick(object sender, RoutedEventArgs e)
        {
            var createFileDialog = new Dialogs.CreateFileDialog();
            createFileDialog.OnEnter((string name) =>
            {
                FileBarViewModel.Instance.CreateFile(name);
                FileBarViewModel.Instance.LoadProject(FileBarViewModel.Instance.RootFileTree.Path);
                return true;
            });
            createFileDialog.ShowDialog();
        }

        private void MenuItem_CreateFolderClick(object sender, RoutedEventArgs e)
        {
            var createFileDialog = new Dialogs.CreateFileDialog();
            createFileDialog.OnEnter((string name) =>
            {
                FileBarViewModel.Instance.CreateFolder(name);
                FileBarViewModel.Instance.LoadProject(FileBarViewModel.Instance.RootFileTree.Path);
                return true;
            });
            createFileDialog.ShowDialog();
        }

        private void MenuItem_CopyPathClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(FileBarViewModel.Instance.SelectedItemNode.Path);
        }

        private void MenuItem_DeletePathClick(object sender, RoutedEventArgs e)
        {
            FileBarViewModel.Instance.DeletePath(FileBarViewModel.Instance.SelectedItemNode.Path);
            FileBarViewModel.Instance.LoadProject(FileBarViewModel.Instance.RootFileTree.Path);
        }
    }
}

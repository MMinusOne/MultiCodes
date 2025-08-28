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
using System.Windows.Shapes;

namespace MultiCodes.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateFileDialog.xaml
    /// </summary>
    public partial class CreateFileDialog : Window
    {
        public CreateFileDialog()
        {
            InitializeComponent();
        }

        Predicate<string> Callback;

        public void OnEnter(Predicate<string> callback) {
            Callback = callback; 
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Callback == null) return;
            Callback(FileNameTextBox.Text);
        }
    }
}

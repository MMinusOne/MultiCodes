using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Bridge;

namespace MultiCodes.ViewModels
{
    public class Console: INotifyPropertyChanged
    {
        static Console _instance;
        public static Console Instance
        {
            get
            {
                if (_instance == null) _instance = new Console();
                return _instance;
            }
        }


        public Console()
        {
            _instance = this;
        }

        ObservableCollection<CLIBlock> _CLIBlocks = new ObservableCollection<CLIBlock> {
            new CLIBlock("", false, false)
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CLIBlock> CLIBlocks
        {
            get { return _CLIBlocks; }
            set { _CLIBlocks = value; OnPropertyChanged(nameof(CLIBlocks));  }
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CLIBlock: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged(nameof(Content)); }
        }

        bool _isUserCommand;
        public bool IsUserCommand
        {
            get { return _isUserCommand; }
            set { _isUserCommand = value; OnPropertyChanged(nameof(IsUserCommand)); }
        }

        bool _executed;
        public bool Executed
        {
            get { return _executed; }
            set { _executed = value; OnPropertyChanged(nameof(Executed)); }
        }

        public CLIBlock(string content, bool isUserCommand, bool executed)
        {
            _content = content;
            _isUserCommand = isUserCommand;
            _executed = executed;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

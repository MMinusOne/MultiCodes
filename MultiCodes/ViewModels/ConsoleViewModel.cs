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
    public class ConsoleViewModel: INotifyPropertyChanged
    {
        static ConsoleViewModel _instance;
        public static ConsoleViewModel Instance
        {
            get
            {
                if (_instance == null) _instance = new ConsoleViewModel();
                return _instance;
            }
        }

        public ConsoleViewModel()
        {
            _instance = this;
        }

        ObservableCollection<CLIBlock> _CLIBlocks = new ObservableCollection<CLIBlock> {
            new CLIBlock("", true, false)
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CLIBlock> CLIBlocks
        {
            get { return _CLIBlocks; }
            set { _CLIBlocks = value; OnPropertyChanged(nameof(CLIBlocks));  }
        }

        public void ExecutePrompt()
        {
            var prompt = CLIBlocks[CLIBlocks.Count-1];
            if (prompt == null) return;
            if(prompt.IsUserCommand && !prompt.Executed)
            {
                var consoleBridge = new Bridge.ConsoleBridge();
                consoleBridge.execute(FileBarViewModel.Instance.RootFileTree.Path, prompt.Content);
                var blocks = consoleBridge.readBlocks();
                var t = consoleBridge.read();
                var block = blocks[blocks.Count-1];
                _CLIBlocks.Add(new CLIBlock(block, false, true));
                _CLIBlocks.Add(new CLIBlock("", true, false));
                OnPropertyChanged(nameof(CLIBlocks));
            }
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
            set {_content = value; OnPropertyChanged(nameof(Content)); }
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

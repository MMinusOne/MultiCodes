using MultiCodes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiCodes.ViewModels
{
    public class CodeEditorViewModel : INotifyPropertyChanged
    {
        static CodeEditorViewModel _instance;
        public static CodeEditorViewModel Instance
        {
            get
            {
                if (_instance == null) _instance = new CodeEditorViewModel();
                return _instance;
            }
        }


        public CodeEditorViewModel()
        {
            _instance = this;
        }

        ObservableCollection<string> _codeLines = new ObservableCollection<string> { };
        public ObservableCollection<string> CodeLines
        {
            get { return _codeLines; }
            set { _codeLines = value; OnPropertyChanged(nameof(CodeLines)); }
        }

        int _fontSize = 15;
        public int FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; OnPropertyChanged(nameof(FontSize)); }
        }

        string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;

                CodeLines.Clear();


                for (int i = 1; i < _code.Length+1; i++)
                {
                    if (_code[i-1] ==  '\n')
                    {
                        CodeLines.Add(CodeLines.Count.ToString());
                    }
                }

                OnPropertyChanged(nameof(Code));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

     

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

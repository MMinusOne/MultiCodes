using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCodes.Lib
{
    public class EditorState: INotifyPropertyChanged
    {
        static EditorState _instance;
        public static EditorState Instance
        {
            get
            {
                if (_instance == null) _instance = new EditorState();
                return _instance;
            }
        }

        bool _hasProjectOpen = false;
        public bool HasProjectOpen
        {
            get { return _hasProjectOpen; }
            set { _hasProjectOpen = value; OnPropertyChanged(nameof(HasProjectOpen)); }
        }

        ObservableCollection<String> _files = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<String> Files
        {
            get { return _files; }
            set { _files = value; OnPropertyChanged(nameof(Files)); }
        }

        public EditorState()
        {

        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

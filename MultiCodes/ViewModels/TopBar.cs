using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

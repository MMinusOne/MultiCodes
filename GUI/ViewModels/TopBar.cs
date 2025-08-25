using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCodes.ViewModels
{
    public class TopBar
    {
        static TopBar _instance;
        static public TopBar Instance { 
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
    }
}

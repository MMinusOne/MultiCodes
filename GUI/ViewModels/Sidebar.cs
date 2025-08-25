using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCodes.ViewModels
{
    public class Sidebar
    {
        static Sidebar _instance;
        public static Sidebar Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Sidebar();
                return _instance;
            }
        }

        public Sidebar()
        {
            _instance = this;
        }
    }
}

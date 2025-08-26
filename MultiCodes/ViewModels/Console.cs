using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiCodes.ViewModels
{
    public class Console
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
    }
}

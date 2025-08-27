using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Bridge;

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


        public Console()
        {
            _instance = this;
            var consoleBridge = new Bridge.ConsoleBridge();
            consoleBridge.execute("cd C:\\Users\\LENOVO\\Downloads\\programming-languages");
            consoleBridge.execute("dir");
            consoleBridge.execute("help");
            var r = consoleBridge.read();

        }

    }
}

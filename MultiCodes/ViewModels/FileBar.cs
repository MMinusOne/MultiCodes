using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCodes.ViewModels
{
    public class FileBar
    {
        static FileBar _instance;
        public static FileBar Instance
        {
            get
            {
                if (_instance == null) _instance = new FileBar();
                return _instance;
            }
        }

        public FileBar()
        {
            _instance = this;
        }
    }
}

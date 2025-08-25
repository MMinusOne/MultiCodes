using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCodes.ViewModels
{
    public class CodeEditor
    {
        static CodeEditor _instance;
        public static CodeEditor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CodeEditor();
                return _instance;
            }
        }

        public CodeEditor()
        {
            _instance = this;
        }
    }
}

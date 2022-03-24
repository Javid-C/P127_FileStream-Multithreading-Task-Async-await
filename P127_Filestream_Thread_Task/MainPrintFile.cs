using System;
using System.Collections.Generic;
using System.Text;

namespace P127_Filestream_Thread_Task
{
    class MainPrintFile  
    {
        public MainPrintFile(IPrintable printable)
        {
            printable.Print();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P127_Filestream_Thread_Task
{
    class Excel : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Excel printed");
        }
    }
}

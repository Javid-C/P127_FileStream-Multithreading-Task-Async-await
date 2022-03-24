using System;
using System.Collections.Generic;
using System.Text;

namespace P127_Filestream_Thread_Task
{
    class PDF : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("PDF printed");
        }
    }
}

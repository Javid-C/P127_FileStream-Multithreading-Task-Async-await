using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P127_Filestream_Thread_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //Word word = new Word();
            //Excel excel = new Excel();
            //PDF pdf = new PDF();
            //MainPrintFile mainPrintFile = new MainPrintFile(word);
            //MainPrintFile mainPrintFile1 = new MainPrintFile(excel);
            //MainPrintFile mainPrintFile2 = new MainPrintFile(pdf);
            //MainPrintFile mainPrintFile3 = new MainPrintFile(new Excel());

            #region FileStream
            //using (FileStream fileStream = new FileStream(@"C:\Users\Lenovo\Desktop\stream\fakhri.txt", FileMode.Create, FileAccess.Write,FileShare.None))
            //{
            //    string text = "Hello P127";
            //    FileStream fileStream1 = new FileStream(@"C:\Users\Lenovo\Desktop\stream\fakhri.txt", FileMode.Create, FileAccess.Write);

            //    byte[] byteArr = Encoding.UTF8.GetBytes(text);
            //    fileStream1.Write(byteArr, 4, byteArr.Length - 4);



            //    fileStream.Write(byteArr,-2,byteArr.Length+2);
            //}



            //StreamWriter streamWriter = new StreamWriter(fileStream);
            //string text = Console.ReadLine();
            //streamWriter.WriteLine(text);

            //streamWriter.Close();


            //fileStream.Close();
            #endregion




            //Thread thread = new Thread(Write0);

            //Thread thread1 = new Thread(Write1);

            //thread.Start();
            //thread1.Start();


            //Task task = Task.Run(delegate ()
            //{
            //    Console.WriteLine("Hello P127");
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Hello Gunel");
            //});
            //task.Wait(1000);

            //Console.WriteLine("Any process");
            //Thread.Sleep(2500);
            //Console.WriteLine(task.IsCompleted);

            //Console.ReadKey();

            //var task = getSource().ContinueWith(t =>
            //{
            //    Console.WriteLine(t.Result.Contains("body"));
            //});

            //string code = getSource();



            //await getSourceAsync();
            //Console.WriteLine(asyncCode.Result);
            //Console.WriteLine("Any process");

            Task<string> code = getSourceAsync();

            Console.Write("Loading");
            int count = 0;
            while (!code.IsCompleted)
            {
                count++;
                if (count <= 3)
                {
                    Thread.Sleep(200);
                    Console.Write(".");
                }
                else
                {
                    count = 0;
                    Console.Clear();
                    Console.Write("Loading");
                }
            }
            Console.Clear();

            Console.WriteLine("Finished");



            Console.ReadLine();
        }

        //CPU bound operations
        //IO bound operations

        public static string getSource()
        {
            HttpClient httpClient = new HttpClient();

            var task = Task.Run(delegate ()
            {
                string text = httpClient.GetStringAsync("https://www.google.com").Result;
                Console.WriteLine("after task result");
                return text;
            });
            Console.WriteLine("Before result");
            string sourceCode = task.Result;
            Console.WriteLine("After result");
            return task.Result;
        }

        public async static Task<string> getSourceAsync()
        {
            HttpClient httpClient = new HttpClient();
            string googleCode = await httpClient.GetStringAsync("https://www.google.com");
            string shazamCode = await httpClient.GetStringAsync("https://www.shazam.com");
            return googleCode;
        }



        public static void Write0()
        {
            for (int i = 0; i < 10000; i++)
            {
                Thread.Sleep(20);
                Console.Write(0);
            }
        }
        public static void Write1()
        {
            for (int i = 0; i < 10000; i++)
            {
                Thread.Sleep(2000);
                Console.Write(1);
            }
        }
    }
}

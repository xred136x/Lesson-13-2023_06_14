using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net.Http.Headers;


namespace Lesson_13_2023_06_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tmp = "ABCD";
            int number;
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < 10; i++)
            {
                number = random.Next(1,100);
                Thread.Sleep(300);
                DateTimeOffset dto = new DateTimeOffset(1970,01,01,0,0,0, TimeSpan.Zero);
                number = number + dto.Millisecond%100;
                sb.Append(number + " ");
                Console.WriteLine(number);
            }
            using(StreamWriter sw = new StreamWriter("output.txt", true))
            {
                sw.WriteLine(sb);
            }
            using(StreamReader sr = new StreamReader("output.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());
            }


            var path = Environment.CurrentDirectory;
            Console.WriteLine(path);
            var myDoc = Environment.SpecialFolder.MyDocuments;
            DirectoryInfo dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles();
            
            foreach(var file in files)
            {
                //var FullFileName = path + "\\" + file;
                FileInfo fileInfo = new FileInfo(file.ToString());
                Console.WriteLine($"{file} {fileInfo.LastWriteTime}" );
            }
            
            Console.ReadKey();
        }
    }
}

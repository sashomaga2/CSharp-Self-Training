using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFilesWithoutLinq(path);
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            Console.WriteLine("LINQ");

            var files = new DirectoryInfo(path).GetFiles().OrderByDescending(d => d.Length).Take(5);

            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;

            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }

            //foreach (var file in files)
            //{
            //    Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            //}
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComperor());
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].Name, -20} : {files[i].Length, 10:N0}");
            }       
        }
    }

    public class FileInfoComperor : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}

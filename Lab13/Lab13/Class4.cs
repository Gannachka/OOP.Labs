using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
        static class PAALog

    {
        static FileSystemWatcher watcher = new FileSystemWatcher
        {
            Path = @"D:\2 курс\ООП\OOP-labs-1.0\Lab13\Lab13\bin\Debug",
            IncludeSubdirectories = true,
            NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
        };
        public static void Start()
        {   
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("paalogfile.txt", true))
            {
                sw.WriteLine(DateTime.Now + "   " + e.ChangeType + "    путь: " + e.FullPath);
            }
        }
    }
}

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
   
   
    
    class Program
    {
        static void Main(string[] args)
        {
            //PAALog log = new PAALog ()
            //SearchByDate("29.12.2019");

             // Начало слежения за Debug в папке с программой
             Thread thread = new Thread(PAALog.Start);
            thread.Start();
       
            // Демонстрация работы LIADiskInfo
            PAADiskInfo.FreeSpace("C:\\");
            PAADiskInfo.FileSystemInfo("C:\\");
            PAADiskInfo.DrivesFullInfo();

            // Демонстрация работы PAADirInfo
            PAADirInfo.FileCount(@"D:\2 курс\ООП\OOP-labs-1.0\");
            PAADirInfo.CreationTime(@"D:\2 курс\ООП\OOP-labs-1.0\");
            PAADirInfo.SubdirectoriesCount(@"D:\2 курс\ООП\OOP-labs-1.0\");
            PAADirInfo.ParentDirectory(@"D:\2 курс\ООП\OOP-labs-1.0\");

            // Демонстрация работы PAAFileInfo
            PAAFileInfo.FullPath(@"D:\in.txt");
            PAAFileInfo.BasicFileInfo(@"D:\in.txt");
            PAAFileInfo.CreationTime(@"D:\in.txt");

            // Демонстрация работы PAAFileManager
            PAAFileManager.InspectDrive(@"D:\");
            PAAFileManager.CopyFiles(@"PAAInspect", ".txt");
            PAAFileManager.ArchiveUnarchive();

            // Остановка процесса наблюдения
            thread.Abort();

            // Удаление каталогов
            Console.WriteLine("Удалить каталоги? 1 - да");
            int key = int.Parse(Console.ReadLine());
            if (key == 1)
            {
                System.IO.Directory.Delete("PAAInspect", true);
                System.IO.Directory.Delete("Unzipped", true);
            }
        }
    }
}

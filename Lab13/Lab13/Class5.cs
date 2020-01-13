using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace Lab13
{
    class PAADirInfo
    {
        public static void SubdirectoriesCount(string path)
        {
            if (Directory.Exists(path))
            {
                string[] dirs = Directory.GetDirectories(path);
                        
                Console.WriteLine($"Количество подкаталогов { dirs.Length}");
            }
        }
        public static void FileCount(string path)
        {
            if (Directory.Exists(path))
            {
                string[] file = Directory.GetFiles(path);
                Console.WriteLine($"Количество файлов:{ file.Length}");
            }
        }

        public static void CreationTime(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            Console.WriteLine($"Время создания файла :{dirInfo.CreationTime}");
        }
        public static void ParentDirectory(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            Console.WriteLine($"Корневой каталог { dirInfo.Root}" );
        }

    }
}

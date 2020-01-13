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
    static class PAAFileManager
    {
        /// Записывает в txt файл содержимое 1-ого уровня указанного диска
        public static void InspectDrive(string driveName)
        {

            DirectoryInfo dir = new DirectoryInfo(driveName);
            FileInfo[] file = dir.GetFiles();
            Directory.CreateDirectory(@"PAAInspect");
            using (StreamWriter sw = new StreamWriter(@"PAAInspect\paadirinfo.txt"))
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                    sw.WriteLine(d.Name);
                foreach (FileInfo f in file)
                    sw.WriteLine(f.Name);
            }
            File.Copy(@"PAAInspect\paadirinfo.txt", @"PAAInspect\paadirinfo_renamed.txt");
            File.Delete(@"PAAInspect\paadirinfo.txt");
        }
        /// Создает папку PAAFiles, копирует в нее файлы из заданного пути по заданному расширению и перемещает папку в PAAFiles
        public static void CopyFiles(string path, string ext)
        {
            string dirpath = @"PAAFiles";
            Directory.CreateDirectory(dirpath);
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Extension == ext)
                    file.CopyTo($@"{dirpath}\{file.Name}");
            }
            Directory.Move(@"PAAFiles", @"PAAInspect\PAAFiles");

        }
        /// Архивация и разархивация
        public static void ArchiveUnarchive()
        {
            string dirpath = @"PAAInspect\PAAFiles";
            string zippath = @"PAAInspect\PAAFiles.zip";
            string unzippath = @"Unzipped";
            ZipFile.CreateFromDirectory(dirpath, zippath);
            ZipFile.ExtractToDirectory(zippath, unzippath);
        }

    }
}

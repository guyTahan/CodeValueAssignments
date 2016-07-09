using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class FileSeeker
    {
       public StringBuilder PresentAllRelevantFiles(string filename,string path)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                

                List<string> dirs = new List<string>();
                getAllDirectories(path, dirs);
                List<DirectoryInfo> dirInfos = getAllDirInfoFiles(dirs);
                List<FileInfo> fileInfos = getAllInfoFiles(dirInfos);

                foreach (FileInfo file in fileInfos)
                {
                    if (file.Name.Contains(filename))
                    {
                        sb.Append(file.Name);
                        sb.Append(" ");
                        sb.AppendLine(file.Length.ToString());
                    }
                }
            }
            catch(UnauthorizedAccessException)
            {
                sb.Clear();
                sb.AppendLine("No Athurity to fully search the given path.");
            }
            catch(PathTooLongException)
            {
                sb.Clear();
                sb.AppendLine("The path you requested to search is too long.");
            }
            catch(ArgumentNullException)
            {
                sb.Clear();
                sb.AppendLine("Path or file name entered are Null.");
            }
            finally
            {
            }

            return sb;
        }
        


        private void getAllDirectories(string path, List<string> directories)
        {
            string[] dirs = Directory.GetDirectories(path);
            if (dirs.Length == 0)
            {
                return;
            }

            directories.Add(path);
            foreach (string dir in dirs)
            {
                getAllDirectories(dir, directories);
            }
        }

        private List<DirectoryInfo> getAllDirInfoFiles(List<string> directories)
        {
            List<DirectoryInfo> dirInfos = new List<DirectoryInfo>();

            foreach(string dir in directories)
            {
                dirInfos.Add(new DirectoryInfo(dir));
            }

            return dirInfos;
        }

        private List<FileInfo> getAllInfoFiles(List<DirectoryInfo> dirInfo)
        {
            List<FileInfo> fileInfos = new List<FileInfo>();

            foreach(DirectoryInfo dirInf in dirInfo)
            {
                fileInfos.AddRange(dirInf.GetFiles());
            }

            return fileInfos;
        }

    }
}

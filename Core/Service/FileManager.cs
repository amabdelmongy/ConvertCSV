using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Service
{
    public interface IFileManager
    {
        List<string> ReadFile(string path);
    }

    public class FileManager : IFileManager
    {  
        public List<string> ReadFile(string path)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }
            return lines;
        }
    }
}

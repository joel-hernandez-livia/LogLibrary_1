using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;

namespace LogLibrary
{
    public class FileLogStorage : ILogStorage
    {
        private readonly string logDirectory;

        public FileLogStorage(string logDirectory)
        {
            this.logDirectory = logDirectory;
            CreateDirectory();
        }

        public void WriteLog(string message)
        {
            string fileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";
            string filePath = Path.Combine(logDirectory, fileName);

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(message);
            }
        }

        private void CreateDirectory()
        {
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Persistance
{
    public class FileWriter:BaseTemplate
    {
        private string fileName;
        public FileWriter(string fileName)
        {
            this.fileName = fileName;
        }
        public override bool TemplateMethod(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Nothing to write to file.");

            if(string.IsNullOrEmpty(fileName))
                throw new Exception("File name is missing");

            using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(value);
                fs.Write(buffer,0,buffer.Length);
            }
            return true;
        }
    }
}

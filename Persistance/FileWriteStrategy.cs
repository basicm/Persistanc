using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class FileWriteStrategy:IStrategyPattern
    {
        readonly BaseTemplate fileWriter = new FileWriter(@"file.txt");

        public bool WriteUsingStrategy(String value)
        {
            try
            {
                // Log into the file
                fileWriter.TemplateMethod(value);
            }
            catch(Exception ex)
            {

            }
            return true;
        }

    }
}

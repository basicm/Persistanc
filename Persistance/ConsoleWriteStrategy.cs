using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class ConsoleWriteStrategy:IStrategyPattern
    {
        public bool WriteUsingStrategy(string value)
        {
            Console.WriteLine("Hello World!");
            return true;
        }
    }
}

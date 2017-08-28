using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance;

namespace TestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IStrategyPattern persistData = Writer_WithStrategy.RunStrategy("CONSOLE");
            persistData.WriteUsingStrategy("Hello World!");

            //persistData = Writer_WithStrategy.RunStrategy("FILE");
            //persistData.WriteUsingStrategy("Hello World!");

            Console.ReadKey();
        }
    }
}

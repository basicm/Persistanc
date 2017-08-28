using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class Writer_WithStrategy
    {
        private readonly IStrategyPattern strategy;
        static ReadConfigFactory readConfigFactory = new ReadConfigFactory("SupportedTypes.xml");

        public Writer_WithStrategy(IStrategyPattern strategy)
        {
            this.strategy = strategy;
        }

        public static IStrategyPattern RunStrategy(string writerType)
        {
            //if (string.IsNullOrEmpty(strategyType))
            //    throw new Exception("Application cannot complete");

            // if strategyType is not provided, write content to console
            IStrategyPattern pattern = (IStrategyPattern)readConfigFactory.GetPersitanceObject(writerType);
            return pattern;

        }
    }
}

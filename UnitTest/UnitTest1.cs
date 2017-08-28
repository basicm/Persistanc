using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp;

namespace UnitTest
{
    [TestClass]
    public class ValidateOutput
    {
        [TestMethod]
        public void ValidateConsoleOutput()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(new string[] { });

                Assert.AreEqual<string>("Hello World!",sw.ToString());
            }
                
        }
    }
}

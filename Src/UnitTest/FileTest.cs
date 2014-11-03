using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Xunit;
namespace UnitTest
{
    class FileTest
    {
        [Fact]
        public void test()
        {
            // Read every line in the file.
            using (StreamReader reader = new StreamReader("file.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Do something with the line.
                    string[] parts = line.Split(',');
                }
            }

            
        }

    }
}

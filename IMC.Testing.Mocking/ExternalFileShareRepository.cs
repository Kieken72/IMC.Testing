using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IMC.Testing.Mocking
{
    public class ExternalFileShareRepository : IExternalFileShareRepository
    {
        public IEnumerable<string> GetAllItems()
        {
            return File.ReadAllLines("myfile.txt");
        }

        public void Save(IEnumerable<string> allLines)
        {
            if (allLines.Any(l => l.Contains("Boem")))
                throw new ArgumentException("Boem!");

            File.WriteAllLines("myfile.txt", allLines);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitDemo.Utility
{
    public static class NameGenerator
    {
        private static string[] _names;
        
        public static string NewName()
        {
            if (_names == null)
            {
                _names = BuildNames();
            }

            var rng = new Random();
            var name = _names[rng.Next(1, _names.Length)].Split(','); //skipping 0 b/c it's the header line;
            return string.Format("{0} {1}", name[0], name[1]);
        }

        private static string[] BuildNames()
        {
            return File.ReadAllLines(@"data\people.csv");
        }
    }
}

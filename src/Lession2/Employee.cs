using System;

namespace Lession2
{
    public class Employee
    {
        public string Name { get; set; }

        public int Gender { get; set; }

        public int Age { get; set; }

        public int Lucky { get; set; }
        
        public int WinRate => (int)Lucky * 100;

    }
}

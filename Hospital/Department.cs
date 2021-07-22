using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Department
    {
        public string Name { get; set; }
        public List<Doctor> Doctors { get; private set; }
        protected Department()
        {
            Doctors = new List<Doctor>();
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
    public class Pediatrics : Department
    {

    }

    public class Stamatology : Department
    {

    }
    public class Traumatology : Department
    {

    }
}

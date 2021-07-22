using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public override string ToString()
        {
            return $"{((Hour > 9) ? "" : "0")}{Hour}:{((Minute > 9) ? "" : "0")}{Minute}";
        }
    }
    public class Reception
    {
        public string PatientName { get; set; }
        public Time Start { get; set; }
        public Time End { get; set; }
        public bool isFull { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class NoDoctorException : ApplicationException
    {
        public NoDoctorException() : base("There is no doctor!")
        {

        }

        public NoDoctorException(string message) : base(message)
        {

        }
    }
}

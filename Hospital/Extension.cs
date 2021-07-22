using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public static class DoctorExtensions
    {
        public static bool CheckAppointment(this Doctor doctor, int appointmentIndex)
        {
            return !doctor.Receptions[appointmentIndex].isFull;
        }
    }
}

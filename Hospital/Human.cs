using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public abstract class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}";
        }
    }

    public class Doctor : Human
    {
        public int ID { get; set; }
        public int WorkYears { get; set; }
        public List<Reception> Receptions { get; private set; }
        public Doctor()
        {
            Receptions = new List<Reception>();
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nWork Years: {WorkYears}";
        }

        public void ReserveReception(int receptionIndex, string patientName)
        {
            Receptions[receptionIndex].isFull = true;
            Receptions[receptionIndex].PatientName = patientName;
        }
    }


    public class User : Human
    {
        public string Mail { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nMail: {Mail}\nPhone: {Phone}";
        }
    }

    public class UserHelper
    {
        public static string GetNameorSurname()
        {
            while (true)
            {
                Console.Write("-> ");
                var name = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(name))
                    return name;

                ConsoleLogger.Error("Enter non-empty value!");
            }
        }

        public static string GetMail()
        {
            while (true)
            {
                Console.Write("-> ");
                var mail = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(mail))
                {
                    if (mail.Split('@').Length == 2)
                        return mail;
                    ConsoleLogger.Error("Mail format is not valid!");
                    continue;
                }

                ConsoleLogger.Error("Enter non-empty value!");
            }
        }

        public static string GetPhoneNumber()
        {
            while (true)
            {
                Console.Write("-> ");
                var phoneNumber = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(phoneNumber))
                {
                    if (CheckPhoneNumber(phoneNumber))
                        return phoneNumber;
                    ConsoleLogger.Error("Phone number does not contain any non-numeric value!");
                    continue;
                }

                ConsoleLogger.Error("Enter non-empty value!");
            }
        }

        private static bool CheckPhoneNumber(string phoneNumber)
        {
            for (var i = 0; i < phoneNumber.Length; i++)
            {
                if (!char.IsDigit(phoneNumber[i]))
                    return false;
            }

            return true;
        }
    }
}

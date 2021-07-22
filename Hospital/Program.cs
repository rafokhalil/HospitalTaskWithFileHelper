using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public enum DepartmentMenuChoice
    {
        Pediatrics = 1, Traumatology, Stamatology
    }


    class Program
    {
        static void Run()
        {
            List<Department> departments = null;
            {
                departments = new List<Department>() {
                    new Pediatrics(){ Name = "Pediatrics"},
                    new Traumatology(){ Name = "Traumatology"},
                    new Stamatology(){ Name = "Stamatology"}
                };
                departments[0].Doctors.Add(new Doctor()
                {
                    ID = 1,
                    Name = "Ismayil",
                    Surname = "Agayev",
                    WorkYears = 3
                });

                departments[0].Doctors.Add(new Doctor()
                {
                    ID = 2,
                    Name = "Roya",
                    Surname = "Xaliqova",
                    WorkYears = 5
                });

                departments[0].Doctors.Add(new Doctor()
                {
                    ID = 3,
                    Name = "Ayten",
                    Surname = "Fettahova",
                    WorkYears = 4
                });

                departments[1].Doctors.Add(new Doctor()
                {
                    ID = 4,
                    Name = "Rafael",
                    Surname = "Xelilzade",
                    WorkYears = 6
                });

                departments[1].Doctors.Add(new Doctor()
                {
                    ID = 5,
                    Name = "Ruslan",
                    Surname = "Mustafayev",
                    WorkYears = 8
                });

                departments[2].Doctors.Add(new Doctor()
                {
                    ID = 6,
                    Name = "Kamran",
                    Surname = "Eliyev",
                    WorkYears = 5
                });

                departments[2].Doctors.Add(new Doctor()
                {
                    ID = 7,
                    Name = "Huseyn",
                    Surname = "Rustemli",
                    WorkYears = 4
                });

                departments[2].Doctors.Add(new Doctor()
                {
                    ID = 8,
                    Name = "Ruslan ",
                    Surname = "Mustafayev",
                    WorkYears = 6
                });

                departments[2].Doctors.Add(new Doctor()
                {
                    ID = 9,
                    Name = "Reshad",
                    Surname = "Dagli",
                    WorkYears = 8
                });
            }



            foreach (var department in departments)
            {
                foreach (var doctor in department.Doctors)
                {
                    doctor.Receptions.Add(new Reception()
                    {
                        PatientName = " ",
                        Start = new Time() { Hour = 9, Minute = 0 },
                        End = new Time() { Hour = 11, Minute = 0 }
                    });

                    doctor.Receptions.Add(new Reception()
                    {
                        PatientName = " ",
                        Start = new Time() { Hour = 12, Minute = 0 },
                        End = new Time() { Hour = 14, Minute = 0 }
                    });

                    doctor.Receptions.Add(new Reception()
                    {
                        PatientName = " ",
                        Start = new Time() { Hour = 15, Minute = 0 },
                        End = new Time() { Hour = 17, Minute = 0 }
                    });
                }
            }

            Console.WriteLine("How many patients are registered today ?");
            int count = int.Parse(Console.ReadLine());
            Console.Clear();
            while (count != 0)
            {
                count--;

                var user = new User();

                Console.WriteLine("Name: ");

                user.Name = UserHelper.GetNameorSurname();

                Console.WriteLine("Surname: ");

                user.Surname = UserHelper.GetNameorSurname();

                Console.WriteLine("Mail: ");

                user.Mail = UserHelper.GetMail();

                Console.WriteLine("Phone number: ");

                user.Phone = UserHelper.GetPhoneNumber();

                Console.WriteLine(user);

                Console.Clear();

                ConsoleScreen.PrintMenu(ConsoleScreen.Departments);

                var mainChoice = ConsoleScreen.Input(ConsoleScreen.Departments.Count) - 1;

                Console.Clear();

                var departmentLoop = true;


                while (departmentLoop)
                {


                    var doctors = departments[mainChoice].Doctors.Select(d => $"{d.Name} {d.Surname}").ToList();
                    doctors.Add("Back");

                    ConsoleScreen.PrintMenu(doctors);

                    var doctorChoice = ConsoleScreen.Input(doctors.Count) - 1;

                    Console.Clear();

                    if (doctorChoice == doctors.Count - 1)
                        break;

                    var doctor = departments[mainChoice].Doctors[doctorChoice];

                    var receptionLoop = true;

                    while (receptionLoop)
                    {
                        var receptions = doctor.Receptions
                            .Select(a => $"{a.Start} - {a.End} ({(a.isFull ? "Reserved" : "Not Reserved")})").ToList();
                        receptions.Add("Back");

                        ConsoleScreen.PrintMenu(receptions);

                        var receptionChoice = ConsoleScreen.Input(receptions.Count) - 1;

                        Console.Clear();

                        if (receptionChoice == receptions.Count - 1)
                            break;

                        var reception = doctor.Receptions[receptionChoice];

                        if (doctor.CheckAppointment(receptionChoice))
                        {
                            var fullName = $"{user.Name} {user.Surname}";

                            foreach (var r in doctor.Receptions)
                            {
                                r.PatientName = fullName;
                            }
                            doctor.ReserveReception(receptionChoice, fullName);

                            ConsoleLogger.Info($"Thanks {fullName} you have signed up for the reception of {doctor.Name} {doctor.Surname} doctor at {reception.Start}");
                            ConsoleScreen.Clear();
                            departmentLoop = false;

                            

                            break;
                        }

                        ConsoleLogger.Error("Appointment is full");
                        ConsoleScreen.Clear();
                    }
                }

            }

            FileHelper.Write(departments);
            



        }






        static void Main(string[] args)
        {
            Run();


        }
    }
}





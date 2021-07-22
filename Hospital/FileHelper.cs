using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hospital
{
    class FileHelper
    {
        public static void Write(List<Department> departments)
        {
            using (var fs = new FileStream("Reception.bin", FileMode.OpenOrCreate))
            {
                using (var bw = new BinaryWriter(fs))
                {

                    foreach (var department in departments)
                    {
                        bw.Write(department.Name);
                        foreach (var doctor in department.Doctors)
                        {
                            bw.Write(doctor.ID);
                            bw.Write(doctor.Name);
                            bw.Write(doctor.Surname);
                            bw.Write(doctor.WorkYears);
                            foreach (var reception in doctor.Receptions)
                            {
                                bw.Write(reception.isFull);
                                bw.Write(reception.PatientName);
                                bw.Write(reception.Start.Minute);
                                bw.Write(reception.Start.Hour);
                                bw.Write(reception.End.Minute);
                                bw.Write(reception.End.Minute);
                            }
                        }
                    }
                }
            }
        }

        //public static void Read(List<Department> departments)
        //{
        //    using (var fs = new FileStream("Reception.bin", FileMode.OpenOrCreate))
        //    {
        //        using (var br = new BinaryReader(fs))
        //        {


        //            foreach (var department in departments)
        //            {
        //                department.Name = br.ReadString();
        //                Console.WriteLine(department);

        //                foreach (var doctor in department.Doctors)
        //                {
        //                    var doc = new Doctor
        //                    {
        //                        ID = br.Read(),
        //                        Name = br.ReadString(),
        //                        Surname = br.ReadString(),
        //                        WorkYears = br.ReadInt32()
        //                    };
        //                    Console.WriteLine(doc);

        //                    foreach (var reception in doctor.Receptions)
        //                    {
        //                        var recp = new Reception
        //                        {
        //                            PatientName = br.ReadString(),
        //                            isFull = br.ReadBoolean(),
        //                            Start = new Time
        //                            {
        //                                Minute = br.ReadInt32(),
        //                                Hour = br.ReadInt32()
        //                            },
        //                            End = new Time
        //                            {
        //                                Minute = br.ReadInt32(),
        //                                Hour = br.ReadInt32()
        //                            }

        //                        };
        //                        Console.WriteLine(recp);
        //                    }
        //                }
        //            }

        //        }
        //    }

        //}
    }
}

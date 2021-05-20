using System;
using System.IO;//For File IO operation.
using System.Collections.Generic;
namespace Entities
{
    class Patient
    {
        public int PatientId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string PatientName { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}\n", PatientId, PatientName, Date.ToShortDateString(), Amount);
        }

        //public static Patient operator =(Patient lhs, Patient other)
        //{
        //    lhs.PatientId = other.PatientId;
        //    lhs.Date = other.Date;
        //    lhs.Amount = other.Amount;
        //    lhs.PatientName = other.PatientName;
        //    return lhs;
        //}
    }
}

//Repository pattern is a design pattern where U create a class that encapsulates the data processing feature of an Application. It hides the operations of the data like CRUD operations. 
namespace DALayer
{
    using Entities;
    interface IPatientRepository
    {
        void AddPatient(Patient p);
        void UpdatePatient(Patient p);
        void DeletePatient(Patient p);
        List<Patient> GetAllPatients();
    }

    class PatientRepository : IPatientRepository
    {
        const string fileName = "AllPatients.csv";
        public void AddPatient(Patient p)
        {
            File.AppendAllText(fileName, p.ToString());
        }

        public void DeletePatient(Patient p)
        {
            var list = getAllPatients();
            var found = list.Find((pt) => pt.PatientId == p.PatientId);
            list.Remove(found);
            saveAll(list);
        }

        public List<Patient> GetAllPatients()
        {
            return getAllPatients();
        }
        //ToDO: fix the bug of Patient updating or identify the bug, will discuss in the next class..
        public void UpdatePatient(Patient p)
        {
            var list = getAllPatients();
            var found = list.Find((pt) => pt.PatientId == p.PatientId);
            found.Amount = p.Amount;
            found.PatientName = p.PatientName;
            found.Date = p.Date;
            saveAll(list);
            
        }

        //Helper function used to save all records after any updating or deleting is done..
        private void saveAll(List<Patient> patients)
        {
            string lines = string.Empty;
            for (int i = 0; i < lines.Length; i++)
                lines += patients[i].ToString();//CSV...
            File.WriteAllText(fileName, lines);
        }

        private List<Patient> getAllPatients()
        {
            List<Patient> all = new List<Patient>();
            string[] allLines = File.ReadAllLines(fileName);
            foreach (string line in allLines)
            {
                var words = line.Split(',');
                Patient p = new Patient();
                p.PatientId = int.Parse(words[0]);
                p.PatientName = words[1];
                p.Date = DateTime.Parse(words[2]);
                p.Amount = int.Parse(words[3]);
                all.Add(p);
            }
            return all;
        }
    }
}

namespace Common
{

}

namespace ConsoleUI
{
    using Entities;
    using DALayer;

    class MainClass
    {
        static IPatientRepository demo = new PatientRepository();
        const string menuFile = @"D:\Phaniraj\Trainings\ReSilence\Training\SampleConApp\Day 7\Menu.txt";
        static void Main(string[] args)
        {
            bool processing = true;
            string content = File.ReadAllText(menuFile);//once and only once in an application execution...
            do
            {
                string choice = MyConsole.GetString(content);
                processing = processMenu(choice);
                MyConsole.GetString("Press Enter to Clear the Screen!!!!");
                Console.Clear();
            } while (processing);
        }

        private static bool processMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    addingPatientHelper();
                    return true;
                case "2":
                    deletingPatientHelper();
                    return true;
                case "3":
                    updatingPatientHelper();
                    return true;
                case "4":
                    findingPatientHelper();
                    return true;
                default:
                    return false;
            }
        }

        private static void findingPatientHelper()
        {
            int id = MyConsole.GetNumber("Enter the ID of the Patient to search");
            //if id isnt given, display all patients, else display on the searched patient
            var list = demo.GetAllPatients();
            foreach(var patient in list)
            {
                if(patient.PatientId == id)
                {
                    Console.WriteLine(patient.Date.ToShortDateString());
                    Console.WriteLine(patient.PatientName);
                    Console.WriteLine(patient.Amount);
                    return;
                }
            }
        }
        //U cannot modify files in b/w in C#. 
        private static void updatingPatientHelper()
        {
            //take inputs for updating the Patient record
            int id = MyConsole.GetNumber("Enter the ID of the Patient to update");
            string name = MyConsole.GetString("Enter the Name to Update");
            int amount = MyConsole.GetNumber("Enter the Bill Amount to Update");
            
            Patient p = new Patient
            {
                Amount = amount,
                PatientId = id,
                PatientName = name
            };
            //call the interface method called AddPatient and pass the object as arg
            try
            {
                demo.UpdatePatient(p);
                Console.WriteLine("Patient updated Successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Adding Patient has failed");
            }
        }

        private static void deletingPatientHelper()
        {
            //take input for the id to delete.
            //call the interface method called DeletePatient and pass the id as arg
            //display any exception messages if required.
        }

        private static void addingPatientHelper()
        {
            //take inputs for creating a Patient
            int id = MyConsole.GetNumber("Enter the ID");
            string name = MyConsole.GetString("Enter the Name");
            int amount = MyConsole.GetNumber("Enter the Bill Amount");
            Patient p = new Patient
            {
                Amount = amount,
                PatientId = id,
                PatientName = name
            };
            //call the interface method called AddPatient and pass the object as arg
            try
            {
                demo.AddPatient(p);
                Console.WriteLine("Patient added Successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Adding Patient has failed");
            }
            //display any exception messages if required.
        }
    }
}
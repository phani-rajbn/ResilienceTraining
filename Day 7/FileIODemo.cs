using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

/*
 * .NET gives classes under a namespace called System.IO that can be used to perform operations on files, directories, drives etc. U can even read binary files as well as text files. 
 * .NET uses Streams to interact with the File Resources. There will be FileStreams, MemoryStreams, TextStreams and many other to perform interactions with different kinds of files in ur OS. 
 * Above this, there is a static class called File that can be used to perform reading and writing operations on text based files. 
 * Every .NET type is implicitly derived from System.Object. Everything is object in .NET/C#. By default, ToString() function of the System.Object will give the name of the Class. U can override it to convert Ur object to a string representation in UR required logical format.
 * CSV, XML(XLINQ), JSON(Web API/REST services) are some of the popular formats of files that data transfers happen in applications.
 */

namespace SampleConApp.Day_7
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
    }
    class FileIODemo
    {
        [STAThread]
        static void Main(string[] args)
        {
            //simpleFileReading();
            //readingSelectedFile();
            //writingAndAppending();
            //ToDo: Create a directory programmatically in UR Drive and store/move contents of our project into that directory. Dont include the Bin directory...
            //Store the details of the Patient as Comma seperated value inside a file. The file appends with new data and will store all the patient records in it. 
            //savePatient();
            //displayAllPatients();
        }

        private static void displayAllPatients()
        {
            List<Patient> allPatients = new List<Patient>();
            string fileName = "Data.csv";
            string[] allLines = File.ReadAllLines(fileName);
            foreach(string line in allLines)
            {
                var words = line.Split(',');
                Patient p = new Patient();
                p.PatientId = int.Parse(words[0]);
                p.PatientName = words[1];
                p.Date = DateTime.Parse(words[2]);
                p.Amount = int.Parse(words[3]);
                allPatients.Add(p);
            }
            foreach(var patient in allPatients)
                Console.WriteLine(patient.PatientName);
        }

        private static void savePatient()
        {
            Patient p = createPatient();
            string filename = "Data.csv";
            File.AppendAllText(filename, p.ToString());
            Console.WriteLine("Patient details added successfully to the database");
        }

        private static Patient createPatient()
        {
            int id = MyConsole.GetNumber("Enter the ID");
            string name = MyConsole.GetString("Enter the Name");
            int amount = MyConsole.GetNumber("Enter the Bill Amount");
            return new Patient
            {
                Amount = amount, PatientId = id, PatientName = name
            };
        }

        private static void writingAndAppending()
        {
            string content = MyConsole.GetString("Enter Some text here");
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
            string filename = dlg.FileName;
            //File.WriteAllText(filename, content);//Overrides the existing content of the file.
            File.AppendAllText(filename, content);
            File.AppendAllText(filename, "\n"); //Moves to the next line
        }

        private static void readingSelectedFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            string filename = dlg.FileName;
            if (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("File not selected");
                return;
            }
            Console.WriteLine(File.ReadAllText(filename));
        }

        private static void simpleFileReading()
        {
            string filename = @"D:\Phaniraj\Trainings\ReSilence\Training\SampleConApp\Day 7\FileIODemo.cs";
            if (File.Exists(filename))
            {
                string content = File.ReadAllText(filename);
                Console.WriteLine(content);
            }
        }
    }
}

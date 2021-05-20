using System;
using System.Runtime.Serialization.Formatters.Binary;//Binary Serialization
using System.Xml.Serialization;//For Xml Serialization..
/*
 * Serialization is an ability of saving an object instead of the data of the object. serialization is required when U want to same state of the object in 2 or more applications. Serialization helps in IPC, database programming and many scenarios where the object should be shared by 2 or more resources at the same time. 
 * In .NET U have 3 types: Binary(Any kind of Data), XML(Platform independent data), SOAP(Web Services).
 * Binary Serialization: Object converted to a binary format and shared thru a binary file is what is called as binary serialization. Binary Serialization expects the class of the object to have an attribute called Serializable. Attributes are additional information set by the programmer on the class, object or its members.
 * U need 3 points for any kind of Serialization: 
 * 1. What to store(objects of class who have attribute called Serializable), 
 * 2. Where to store(Memorystreams, BinaryStreams, FileStreams). 
 * 3. Format of storing(Binary or XML).
 * After serializing the object, if U want to read the serialized object, U should de-serialize it and then read it. 
 * If a derived class object has to be serialized, then the base class as well the derived class should have the [serializable] attribute. Most of the .NET Classes and Value types are implicitly serializable
 * XML Serialization:
 * Here the class need not be Serializable but it should be public. The members should also be public members. The class called XmlSerializer is used instead of BinaryFormatter. Rest of the functions and sequence are same.
 *limitations: 
 *U cannot append the file in Serialization, either the whole file is read/written or nothing happens.
 *Data can easily get corrupted and U might never get the data back. It is not secured.
 *Applications are not scalable, it is not suited for multi user environment. 
 */
namespace SampleConApp.Day_7
{
    using System.IO;
    [Serializable]//This attribute makes the objects of this class storable as objects instead of data. 
    public class Data
    {
        public int DataId { get; set; }
        public string DataName { get; set; }
    }
    class SerializationDemo
    {
        const string filename = "serialization.bin";
        static void Main(string[] args)
        {
            //serializingExample();
            //deserializingExample();
            //xmlSerializingExample();
            //XmlDeserialization();
        }

        //TODO: Develop an Application that uses XML Serialization and stores all the data using CRUD operations,
        private static void XmlDeserialization()
        {
            FileStream fs = new FileStream("XmlData.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xmlSl = new XmlSerializer(typeof(Data));
            Data savedObj = xmlSl.Deserialize(fs) as Data;
            fs.Close();
            Console.WriteLine($"The Saved data is {savedObj.DataId} and {savedObj.DataName}");
        }

        private static void xmlSerializingExample()
        {
            Data data = new Data { DataId = 124, DataName = "New Data" };
            FileStream fs = new FileStream("XmlData.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(Data));
            serializer.Serialize(fs, data);
            fs.Close();
        }

        private static void deserializingExample()
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryFormatter fm = new BinaryFormatter();
            Data ds = fm.Deserialize(fs) as Data;
            fs.Close();
            Console.WriteLine($"The data values are {ds.DataName} and {ds.DataId}" );
        }

        private static void serializingExample()
        {
            Data obj = new Data { DataId = 123, DataName = "SomeExample" };//What
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);//Where
            BinaryFormatter fm = new BinaryFormatter();//How
            fm.Serialize(fs, obj);
            fs.Close();//Close the stream once the serialization is completed.
        }
    }
}

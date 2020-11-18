using CsvHelper;
using cw2.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string zrodlo = "data.csv", result = "result.xml", format = "xml";
           
            

            if (args.Length >= 1)
            {
                    zrodlo = args[0];
            }
            if (args.Length >= 2)
            {
                result = args[1];
            }
            if (args.Length >= 3)
            {
                format = args[2];
            }
            try
            {
                using (StreamReader reader = new StreamReader(zrodlo))


                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    Student student = new Student();
                    csv.Configuration.HasHeaderRecord = false;
                    List<Student> records = csv.GetRecords<Student>().ToList();

                    FileStream writer = new FileStream(result, FileMode.Create);
                    if (format.Equals("xml"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
                        serializer.Serialize(writer, records);
                        writer.Close();
                    }
                    if (format.Equals("json"))
                    {
                        string jsonString = JsonSerializer.Serialize(records);
                        File.WriteAllText("data.json", jsonString);
                    }
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                using (FileStream fs = File.Create("log.txt"))
                {
                    AddText(fs, "FileNotFoundException: Plik nazwa nie istnieje\r");
                    AddText(fs, e.Message);
                 
                }
            }
        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}

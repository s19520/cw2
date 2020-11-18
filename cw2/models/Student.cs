using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace cw2.models
{
    [Serializable]
    public class Student
    {
        [Index(0)]
        [JsonPropertyName("Imie")]
        public string fname { get; set; }
        [Index(1)]
        
        public string lname { get; set; }
        [Index(2)]
        public string studies { get; set; }
        [Index(3)]
        public string mode { get; set; }
        [Index(4)]
        [XmlAttribute("indexName")]
        public string IndexNumber { get; set; }
        [Index(5)]
        public DateTime birthdate { get; set; }
        [Index(6)]
        public string mothersName { get; set; }
        [Index(7)]
        public string fathersName { get; set; }
    }
    
    
}

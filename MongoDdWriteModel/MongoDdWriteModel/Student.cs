using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MongoDdWriteModel
{
    public class Student
    {
        [BsonId(IdGenerator =typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("phoneNr")]
        public string PhoneNr { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("classes")]
        public string[] Classes { get; set; }


        //[BsonConstructor]
        public Student(string name, string address)
        {
            Id = Guid.NewGuid().ToString();
            Address = new Address(address);
            Name = name;  
            Classes = new [] { "NøkkelKompetanse" , "C#" };           
        }
    }
}

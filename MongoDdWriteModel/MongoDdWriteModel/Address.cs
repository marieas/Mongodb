using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDdWriteModel
{
    public class Address
    {
        [BsonElement("streetName")]
        public string StreetName { get; set; }

        [BsonElement("municipality")]
        public string Municipality { get; set; }

        [BsonElement("areaCode")]
        public int AreaCode { get; set; }

        public Address(string address)
        {
           var adrFields =  address.Split(',');
            StreetName = adrFields[0];
            Municipality = adrFields[1];
            AreaCode = int.Parse(adrFields[2]);
        }

        public string GetAddressAsString()
        {
            return $"{StreetName},{Municipality},{AreaCode}";
        }
    }
}

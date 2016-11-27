using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2.Models
{
    public class Patient
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ailment> Ailment { get; set; }
        public ICollection<Medication> Medications { get; set; }

    }

    public class Medication
    {
        public string Name { get; set; }
        public string Doses { get; set; }
    }

    public class Ailment
    {
        public string Name { get; set; }
    }
}
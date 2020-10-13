using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace uppgit_1_nr2
{

    [BsonDiscriminator(Required = true, RootClass = true)]
    [BsonKnownTypes(typeof(Book), typeof(Movie))]
    public abstract class Item
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public int TotalCount { get; set; }
    }
}

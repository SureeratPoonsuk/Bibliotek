using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace uppgit_1_nr2
{
   public  class Member
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Member(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }


}

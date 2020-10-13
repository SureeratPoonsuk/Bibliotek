using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace uppgit_1_nr2
{
    public class Loan
    {
        public ObjectId Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Member Member { get; set; }
        public Item Item { get; set; }

        public Loan(Member member, Item item, DateTime start,DateTime end)
        {
            Member = member;
            Item = item;
            StartDate = start;
            EndDate = end;
        }
    }
}

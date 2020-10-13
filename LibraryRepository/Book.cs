using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace uppgit_1_nr2
{
    public class Book : Item 
    {
        public string Author { get; set; }

        public Book(string title, string author, int count) // konstrukter som vi skicka in 2 stränga
        {
            Title = title; // hamna i de två properties
            Author = author;
            TotalCount = count; // hur många exempla av böcker och film
        }
    }
}

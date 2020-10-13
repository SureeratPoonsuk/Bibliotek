using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace uppgit_1_nr2
{
    public class Movie : Item
    {
        public string Language { get; set; } // deklarera det finns variabel

        public Movie(string title, string language, int count)
        {
            Title = title; //initialisera man ge variebel ett väder
            Language = language;
            TotalCount = count;
        }


    }
}

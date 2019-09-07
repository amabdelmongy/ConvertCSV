using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{  
    public class Person
    {  
        public int ID { get; set; }
        public string Name  { get; set; }
        public string Lastname { get; set; }
        public string Zipcode  { get; set; }
        public string City  { get; set; }
        public Color Color  { get; set; } 
    }

    public enum Color
    {
        blue = 1,
        green,
        purple,
        red,
        yellow,
        turquois,
        white,
    }
}

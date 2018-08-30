using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    public class Destination
    {
        public int Id { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }

        public Destination(string Pays, string Region) { }
        public Destination(string Pays, string Region, string Description) { }
    }
}

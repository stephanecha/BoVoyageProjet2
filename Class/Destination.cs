using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    public class Destination
    {
        public int Id { get; set; }
        public string Continent { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }

        public Destination(string continent ,string pays, string region)
        {
            Continent = continent;
            Pays = pays;
            Region = region;
        }
        public Destination(string continent ,string pays, string region, string description)
        {
            Continent = continent;
            Pays = pays;
            Region = region;
            Description = description;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT_Lab4
{
    class Building
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string StreetNo { get; set; }
        public int FloorsCount { get; set; }
        public int AptsCount { get; set; }
        public List<Apartment> Apartments { get; set; }

    public Building() { }

        public Building(string city, string strName, string strNo, int floorsCount, int aptsCount )
        {
            City = city;
            StreetName = strName;
            StreetNo = strNo;
            FloorsCount = floorsCount;
            AptsCount = aptsCount;
        }

        public override string ToString()
        {
            return City + ", " + StreetName + " " + StreetNo + ", floors: " + FloorsCount + " apartments: " + AptsCount;
        }

    }
}

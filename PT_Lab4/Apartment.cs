using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT_Lab4
{
    class Apartment
    {
        public int Id { get; set; }
        public string AptNo { get; set; }
        public int Floor { get; set; }
        public float Area { get; set; }
        public Owner Owner { get; set; }

        public Apartment() { }
        public Apartment(string aptNo, int floor, float area, Owner owner=null)
        {
            AptNo = aptNo;
            Floor = floor;
            Area = area;
            this.Owner = owner;
        }

        public override string ToString()
        {
            return "No " + AptNo + ", floor: " + Floor + ", area: " + Area + " m2" /*owner: " + this.Owner.ToString()*/;
        }

        public static void ShowApartmentsTable()
        {
            Console.Clear();
            var db = new DeveloperBase();
            var apartments = db.Apartments.ToList();
            foreach (Apartment apartment in apartments)
                Console.WriteLine(apartment.ToString());
            Console.ReadLine();
            Console.WriteLine("=====================================");
            Console.WriteLine("|\tOptions:");
            Console.WriteLine("=====================================");
            Console.WriteLine("1) Add new Apartment entry");
            Console.WriteLine("2) Delete existing Apartment");
            Console.WriteLine("3) Change existing Apartment");
            Console.WriteLine("4) Back to previous menu");
            Console.Write("OPTION: ");
            switch (Console.Read())
            {
                case 49:
                    AddNewApartment();
                    break;
                case 50:
                    DeleteApartment();
                    break;
                case 51:
                    UpdateApartment();
                    break;
                case 52:
                    Program.ShowMainMenu();
                    break;
            }
        }

        public static void AddNewApartment()
        {
            var db = new DeveloperBase();

            var uselessVariable = Console.ReadLine();
            Console.WriteLine("=====================================");
            Console.WriteLine("Creating new Apartment entry...");
            string number;
            Console.Write("Enter Apartment nubmer: ");
            number = Console.ReadLine();
            int floor;
            Console.Write("Enter Apartment floor: ");
            floor = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Apartment area [m2]: ");
            float area = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Owner id: ");
            int ownersId = int.Parse(Console.ReadLine());
            Owner apartmentsOwner = db.Owners.Find(ownersId);

            
            
            db.Apartments.Add(new Apartment(number,floor,area, apartmentsOwner));
            db.SaveChanges();
            ShowApartmentsTable();
        }

        public static void DeleteApartment()
        {

        }

        public static void UpdateApartment()
        {

        }
    }
}

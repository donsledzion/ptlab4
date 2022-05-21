using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DeveloperBase();

            Console.WriteLine($"Database path: {db.DbPath}");
            
            while(true)
            {
                ShowMainMenu();
            }
        }

        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("|\tReal Estates Manager 2.0 - stable\t\t|");
            Console.WriteLine("========================================================");
            Console.WriteLine("|\tMAIN MENU:\t\t\t\t\t|");
            Console.WriteLine("--------------------------------------------------------|");
            Console.WriteLine("| 1) Show owners table\t\t\t\t\t|");
            Console.WriteLine("| 2) Show buildings table\t\t\t\t|");
            Console.WriteLine("| 3) Show apartments table\t\t\t\t|");
            Console.WriteLine("========================================================");
            Console.Write("OPTION: ");
            switch (Console.Read())
            {             
                case 49:
                    Owner.ShowOwnersTable();
                    break;
                case 50:
                    ShowBuildingsTable();
                    break;
                case 51:
                    ShowApartmentsTable();
                    break;
                
            }
        }

        

        public static void ShowBuildingsTable()
        {
            var uselessVariable = Console.ReadLine();
            Console.Clear();
            var db = new DeveloperBase();
            var buildings = db.Buildings.ToList();
            foreach (Building building in buildings)
                Console.WriteLine(building.ToString());
            Console.ReadLine();
            ShowMainMenu();
        }

        public static void ShowApartmentsTable()
        {
            var uselessVariable = Console.ReadLine();
            Console.Clear();
            var db = new DeveloperBase();
            var apartments = db.Apartments.ToList();
            foreach (Apartment apartment in apartments)
                Console.WriteLine(apartment.ToString());
            Console.ReadLine();
            ShowMainMenu();
        }
    }
}

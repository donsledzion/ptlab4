using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT_Lab4
{
    class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public Owner() { }
        public Owner(string firstName, string lastName, int age, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        public override string ToString()
        {
            return Id + "\t|" + FirstName + " " + LastName + ", " + Age + " years old " + Gender.ToString();
        }

        public static void ShowOwnersTable()
        {
            Console.Clear();
            var db = new DeveloperBase();
            var owners = db.Owners.ToList();
            foreach (Owner owner in owners)
                Console.WriteLine(owner.ToString());
            Console.ReadLine();
            Console.WriteLine("=====================================");
            Console.WriteLine("|\tOptions:");
            Console.WriteLine("=====================================");
            Console.WriteLine("1) Add new Owner entry");
            Console.WriteLine("2) Delete existing Owner");
            Console.WriteLine("3) Change existing Owner");
            Console.WriteLine("4) Back to previous menu");
            Console.Write("OPTION: ");
            switch (Console.Read())
            {
                case 49:
                    AddNewOwner();
                    break;
                case 50:
                    DeleteOwner();
                    break;
                case 51:
                    UpdateOwner();
                    break;
                case 52:
                    Program.ShowMainMenu();
                    break;
            }
        }

        public static void AddNewOwner()
        {
            var uselessVariable = Console.ReadLine();
            Console.WriteLine("=====================================");
            Console.WriteLine("Creating new Owner entry...");
            string fname;
            Console.Write("Enter first name: ");
            fname = Console.ReadLine();
            string lname;
            Console.Write("Enter last name: ");
            lname = Console.ReadLine();
            Console.WriteLine("Enter age [years]: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter gender: ");
            Console.WriteLine("1 - Female");
            Console.WriteLine("2 - Male");
            Gender gender = Gender.Female;
            switch (Console.Read())
            {
                case 49:
                    gender = Gender.Female;
                    break;
                case 50:
                    gender = Gender.Male;
                    break;
            }
            var db = new DeveloperBase();
            db.Owners.Add(new Owner(fname, lname, age, gender));
            db.SaveChanges();
            ShowOwnersTable();
        }

        public static void DeleteOwner()
        {
            var uselessVariable = Console.ReadLine();
            Console.WriteLine("=====================================");
            Console.WriteLine("Deleting existing Owner entry...");
            var db = new DeveloperBase();
            Console.WriteLine("=====================================");
            int id;
            Console.Write("Enter id of Owner to delete: ");
            id = int.Parse(Console.ReadLine());
            var ownerToRemove = db.Owners.SingleOrDefault(x => x.Id == id); //returns a single item.
            Console.WriteLine("Given id: " + id);
            if (ownerToRemove != null)
            {
                Console.WriteLine(ownerToRemove.ToString() + " will be deleted...");
                db.Owners.Remove(ownerToRemove);
                db.SaveChanges();
                Console.WriteLine("Owner entry has been deleted...");
            }
            else
            {
                Console.WriteLine("An error ocurred deleting Owner entry");
            }
        }

        public static void UpdateOwner(int id = -1)
        {
            var db = new DeveloperBase();
            if (id < 0)
            {
                var uselessVariable = Console.ReadLine();
                Console.WriteLine("=====================================");
                Console.WriteLine("Updating existing Owner entry...");
                //var db = new DeveloperBase();
                Console.WriteLine("=====================================");
                Console.Write("Enter id of Owner to delete: ");
                id = int.Parse(Console.ReadLine());
            }
            var ownerToUpdate = db.Owners.SingleOrDefault(x => x.Id == id); //returns a single item.
            Console.WriteLine("Given id: " + id);
            if (ownerToUpdate != null)
            {
                Console.WriteLine(ownerToUpdate.ToString() + " will be updated...");
                Console.Clear();
                Console.WriteLine("=========================");
                Console.WriteLine(" Owner ID: " + id);
                Console.WriteLine("-------------------------");
                Console.WriteLine("1) First name: " + ownerToUpdate.FirstName);
                Console.WriteLine("2) Last name: " + ownerToUpdate.LastName);
                Console.WriteLine("3) Age: " + ownerToUpdate.Age);
                Console.WriteLine("4) Gender: " + ownerToUpdate.Gender);
                Console.WriteLine("=========================");
                Console.WriteLine("Enter number of value to edit or [Q] to quit:");
                Console.Write("Edit value no: ");

                switch (Console.Read())
                {
                    case 49:
                        EditFirstName(ownerToUpdate);
                        break;
                    case 50:
                        EditLastName(ownerToUpdate);
                        break;
                    case 51:
                        EditAge(ownerToUpdate);
                        break;
                    case 52:
                        EditGender(ownerToUpdate);
                        break;
                    case 113:
                        EditFirstName(ownerToUpdate);
                        break;
                }

                Console.ReadLine();
                db.SaveChanges();
                Console.WriteLine("Owner entry has been updated...");
            }
            else
            {
                Console.WriteLine("An error ocurred updating Owner's entry");
            }
        }

        private static void EditFirstName(Owner owner)
        {
            Console.ReadLine();
            Console.WriteLine("=========================");
            Console.WriteLine(" Owner ID: " + owner.Id);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Current First name: " + owner.FirstName);
            Console.Write("Enter new First name: ");
            string newFirstName = Console.ReadLine();
            var db = new DeveloperBase();
            Owner updatedOwner = db.Owners.Find(owner.Id);
            updatedOwner.FirstName = newFirstName;
            db.SaveChanges();
            //ShowOwnersTable();
            UpdateOwner(owner.Id);
        }

        private static void EditLastName(Owner owner)
        {
            Console.ReadLine();
            Console.WriteLine("=========================");
            Console.WriteLine(" Owner ID: " + owner.Id);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Current Last name: " + owner.LastName);
            Console.Write("Enter new Last name: ");
            string newLastName = Console.ReadLine();
            var db = new DeveloperBase();
            Owner updatedOwner = db.Owners.Find(owner.Id);
            updatedOwner.LastName = newLastName;
            db.SaveChanges();
            //ShowOwnersTable();
            UpdateOwner(owner.Id);
        }

        private static void EditAge(Owner owner)
        {
            Console.ReadLine();
            Console.WriteLine("=========================");
            Console.WriteLine(" Owner ID: " + owner.Id);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Current Age: " + owner.Age);
            Console.Write("Enter new Age: ");
            int newAge = int.Parse(Console.ReadLine());
            var db = new DeveloperBase();
            Owner updatedOwner = db.Owners.Find(owner.Id);
            updatedOwner.Age = newAge;
            db.SaveChanges();
            //ShowOwnersTable();
            UpdateOwner(owner.Id);
        }

        private static void EditGender(Owner owner)
        {
            Console.ReadLine();
            Console.WriteLine("=========================");
            Console.WriteLine(" Owner ID: " + owner.Id);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Current Gender: " + owner.Gender);
            Console.WriteLine("Pick new Gender: ");
            Console.WriteLine("=========================");
            Console.WriteLine("1 - Female");
            Console.WriteLine("2 - Male");
            int selection = int.Parse(Console.ReadLine());
            Gender newGender = owner.Gender;
            if (selection == 1)
                newGender = Gender.Female;
            if (selection == 2)
                newGender = Gender.Male;
            var db = new DeveloperBase();
            Owner updatedOwner = db.Owners.Find(owner.Id);
            updatedOwner.Gender = newGender;
            db.SaveChanges();
            //ShowOwnersTable();
            UpdateOwner(owner.Id);
        }
    }

    public enum Gender
    {
        Male,
        Female
    }


}

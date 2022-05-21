namespace PT_Lab4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PT_Lab4.DeveloperBase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PT_Lab4.DeveloperBase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Buildings.AddOrUpdate(
                /*public Building(string city, string strName, string strNo, int floorsCount, int aptsCount)*/
                new Building("Kraków", "Krowoderska", "67", 4, 42),
                new Building("Kraków", "Świętokrzyska", "13", 12, 310),
                new Building("Kraków", "Mogilska", "115B", 22, 391),
                new Building("Wrocław", "Kolista", "11", 10, 275),
                new Building("Wrocław", "Kozanowska", "61A", 12, 220),
                new Building("Gdańsk", "Żabi Kruk", "13", 10, 40),
                new Building("Gdańsk", "Żabi Kruk", "11", 10, 40)
                );

            context.Apartments.AddOrUpdate(
                new Apartment("14A", 1, 56.7f, new Owner("Jan", "Kowalski", 38, Gender.Male)),
                new Apartment("14B", 1, 56.7f, new Owner("Marian", "Gałązka", 82, Gender.Male)),
                new Apartment("11A", 1, 56.7f, new Owner("Wioletta", "Blokas", 44, Gender.Female)),
                new Apartment("11B", 1, 56.7f, new Owner("Helena", "Karniszek", 19, Gender.Female)),
                new Apartment("12A", 1, 56.7f, new Owner("Krzysztof", "Jarzyna", 64, Gender.Male)),
                new Apartment("12B", 1, 56.7f, new Owner("Marianna", "Kiełbasa", 25, Gender.Female))
                );

            context.Owners.AddOrUpdate(
                new Owner("Zenon", "Kufajka", 21, Gender.Male),
                new Owner("Zbigniew", "Wajcha", 19, Gender.Male),
                new Owner("Agnieszka", "Slósarz", 52, Gender.Female),
                new Owner("Wiesława", "Czaja", 45, Gender.Female),
                new Owner("Leon", "Trojanowicz", 30, Gender.Male)
                );
        }
    }
}

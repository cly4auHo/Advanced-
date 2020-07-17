using System;
using System.Collections.Generic;
using System.Linq;

namespace Home4.CarShop
{
    public class ShopMain
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Owner> owners = new List<Owner>();

            Owner alex = new Owner("Alex", 380336549880);
            Owner alexandr = new Owner("Alexandr", 380316559489);
            Owner max = new Owner("Max", 380371549865);
            owners.Add(alex);
            owners.Add(alexandr);
            owners.Add(max);

            Car focus = new Car(alex, 2015, "Ford", "Focus", "White");
            Car civic = new Car(alex, 2008, "Honda", "Civic", "Red");
            Car supra = new Car(max, 1987, "Toyota", "Supra", "Red");
            Car viper = new Car(alexandr, 2015, "Dodge", "Viper", "Black");
            cars.Add(focus);
            cars.Add(civic);
            cars.Add(supra);
            cars.Add(viper);

            var result = from car in cars
                         join owner in owners
                         on car.Owner equals owner
                         select new
                         {
                             Owner = car.Owner,
                             Model = car.Model,
                             Mark = car.Mark,
                             year = car.ReleaseDate,
                             Colour = car.Colour
                         };

            foreach (var item in result)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}


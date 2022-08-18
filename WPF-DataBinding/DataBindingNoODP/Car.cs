using System.Collections.Generic;

namespace DataBindingNoODP
{

    public enum CarType
    {
        SUV,
        Sedan,
        Hatchback
    }
    public class Car
    {
        public string Owner { get; set; }
        public CarType Type { get; set; }
    }

    public class Cars
    {
        public static List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car() { Owner = "Mike", Type = CarType.Hatchback},
                new Car() { Owner = "Alex", Type = CarType.Sedan},
                new Car() { Owner = "Soo", Type = CarType.SUV}
            };
        }

    }
}

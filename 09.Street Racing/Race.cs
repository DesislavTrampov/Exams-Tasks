using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        List<Car> Races { get; set; }=new List<Car>();

        public int Count => Races.Count;


        public void Add(Car car)
        {
            
            if(car.HorsePower <= MaxHorsePower && Races.Count < Capacity)
            {
                if (!Races.Contains(car))
                {
                    Races.Add(car);
                }

                
            }
        }
        public bool Remove(string licensePlate)
        {
            Car car = Races.FirstOrDefault(x=>x.LicensePlate==licensePlate);

            if (car == null)
            {
                return false;
            }
            Races.Remove(car);
            return true;

        }
        public Car FindParticipant(string licensePlate)
        {
            Car cars = Races.FirstOrDefault(x => x.LicensePlate == licensePlate);
            return cars == null ? null : cars;
        }
        public Car GetMostPowerfulCar()
        {
            Car cars = Races.OrderByDescending(x => x.HorsePower).FirstOrDefault();
            return cars == null ? null : cars;

        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach(var item in Races)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().Trim();

        }
    }
}

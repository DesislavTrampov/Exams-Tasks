using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            
        }

        public string  Type { get; set; }
        public int Capacity { get; set; }

        public int Count => Data.Count;
        public List<Car> Data { get; set; } = new List<Car>();

        public void Add(Car car)
        {
           if (!Data.Contains(car)&& Data.Count<Capacity)
            {
                Data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
          Car cars = Data.FirstOrDefault(x => x.Model == model && x.Manufacturer == manufacturer);
           
            if ( cars != null)
            {
                Data.RemoveAll(x => x.Model == model && x.Manufacturer == manufacturer);
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public Car GetLatestCar()
        {
           Car car = Data.OrderByDescending(x => x.Year).First();
            return car;
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car cars = Data.FirstOrDefault(x=>x.Manufacturer==manufacturer && x.Model==model);
            if (Data == null)
            {
                return null;
            }
            return cars;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"The cars are parked in {Type}:");

            foreach(Car car in Data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}

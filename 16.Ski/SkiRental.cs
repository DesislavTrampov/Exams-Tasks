using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }
        public List<Ski> Skis { get; set; } = new List<Ski>();

        public int Count => Skis.Count;

        public void Add(Ski ski)
        {
            if (!Skis.Contains(ski))
            {
                Skis.Add(ski);
            }
           
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski ski = Skis.FirstOrDefault(x=>x.Manufacturer == manufacturer && x.Model == model);
            if (ski!=null)
            {
                Skis.Remove(ski);
                return true;

            }
            return false;

        }
        public Ski GetNewestSki()
        {
            Ski ski = Skis.OrderByDescending(x => x.Year).FirstOrDefault();
            if (ski == null)
            {
                return null;
            }
            return ski;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = Skis.FindAll(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();
            if (ski != null)
            {
                return ski;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in Skis)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

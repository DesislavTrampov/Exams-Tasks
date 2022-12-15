using FishingNet;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Capacity = capacity;
            Material = material;
            //Fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public List<Fish> Fish { get; set; } = new List<Fish>();

        public int Count
        {
            get
            {
                return Fish.Count;
            }
        }




        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) && fish.Length <= 0 && fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Fish.Count >= Capacity)
            {
                return "Fishing net is full.";
            }

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";

        }
        public bool ReleaseFish(double weight)
        {
            Fish fish = Fish.FirstOrDefault(x => x.Weight == weight);

            if (fish == null)
            {
                return false;
            }
            else
            {
                Fish.RemoveAll(x => x.Weight == weight);
                return true;
            }

        }
        public Fish GetFish(string fishType)
        {
            Fish fish = Fish.FindAll(x => x.FishType == fishType).First();
            return fish;
        }
        public Fish GetBiggestFish()
        {
            Fish fish = Fish.OrderByDescending(x => x.Length).First();

            return fish;

        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            foreach (var f in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(f.ToString());
            }
            return sb.ToString().Trim();
        }
    }

}


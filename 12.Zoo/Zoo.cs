using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Markup;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
         Capacity = capacity;
          Name = name;

        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Animal> Animals { get; set; }= new List<Animal>();

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet!= "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (Animals.Count >= Capacity)
            {
                return "The zoo is full.";

            }
            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            int curent = Animals.Count;
           Animals.RemoveAll(a => a.Species == species);
            int sum = curent - Animals.Count;
            return sum;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var list = Animals.Where(a => a.Diet == diet).ToList();
            return list;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            var list = Animals.FindAll(x=>x.Weigth==weight).First();
            return list;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            Animals.Where(a=>a.Length>minimumLength && a.Length<maximumLength).ToList();

            return $"There are {Animals.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}

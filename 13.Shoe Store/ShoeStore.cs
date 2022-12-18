using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            
        }

        public string Name { get; set; }

        public int StorageCapacity { get; set; }


        public List<Shoe> Shoes { get; set; } = new List<Shoe>();


       public int Count => Shoes.Count;

        public  string AddShoe(Shoe shoe)
        {

            if(Shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            
            else if(!Shoes.Contains(shoe))
            {
                Shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            return null;
        }
        public int RemoveShoes(string material)
        {
            int count = Shoes.Count;
             //Shoes.Where(sh => sh.Material == material).ToList();
             Shoes.RemoveAll(x=>x.Material==material);
            
            return count -Shoes.Count;
        }
        public 	List<Shoe> GetShoesByType(string type)
        {


           var list = Shoes.Where(x=>x.Type.ToLower()== type.ToLower()).ToList();

            return list;
            
        }
        public Shoe GetShoeBySize(double size)
        {
            Shoe shoe = Shoes.Where((x)=>x.Size==size).First();

            return shoe;
        }
         public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();
           
            List<Shoe> shoes = Shoes.FindAll(x=>x.Size >= size&&x.Type == type).ToList();

            sb.AppendLine($"Stock list for size {size} - {type} shoes:");
            foreach (Shoe shoe in shoes)
            {
                sb.AppendLine(shoe.ToString());
               
            }
            if (shoes.Count==0)
            {
                return "No matches found!";
            }
            return sb.ToString().TrimEnd();
        }

    }
}

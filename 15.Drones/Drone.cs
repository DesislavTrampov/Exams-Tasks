using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Drones
{
    public class Drone
    {
		public Drone(string name,string brand,int range)
		{
			Name = name;
			Brand = brand;
			Range = range;

        }
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private string brand;

		public string Brand
		{
			get { return brand; }
			set { brand = value; }
		}
		private int range;

		public int Range
		{
			get { return range; }
			set { range = value; }
		}
		private bool available = true;

		public bool Available
		{
			get { return available; }
			set { available = value; }
		}




		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Drone: {Name}" +
				Environment.NewLine +
				$"Manufactured by: {Brand}" + Environment.NewLine +
				$"Range: {Range} kilometers");


			return sb.ToString().TrimEnd();

        }
	}
}

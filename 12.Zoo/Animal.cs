using System.Text;

namespace Zoo
{
    public class Animal
    {

		public Animal(string species,string diet,double weigth,double length)
		{
			Species = species;
			Diet = diet;
			Weigth = weigth;
			Length = length;
			
		}


		private string species;

		public string Species
		{
			get { return species; }
			set { species = value; }
		}

		private string diet;

		public string Diet
		{
			get { return diet; }
			set { diet = value; }
		}
		private double weight;

		public double Weigth
		{
			get { return weight; }
			set { weight = value; }
		}

		private double length;

        public double Length
        {
			get { return length; }
			set { length = value; }
		}
		public override string ToString()
		{
		 StringBuilder sb = new StringBuilder();
			sb.AppendLine($"The {Species} is a {Diet} and weighs {Weigth} kg.");
			return sb.ToString().Trim();
		}

	}
}

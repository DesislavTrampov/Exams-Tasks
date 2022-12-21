using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Drones
{
    public class Airfield
    {

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }
        public List<Drone> Drones { get; set; } = new List<Drone>();
        public int Count => Drones.Count;


        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand)) 
            { 
                return "Invalid drone.";
            }
            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            
            if (Drones.Count >= Capacity)
            {
                return "Airfield is full.";
            }


            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {

            Drone drone = Drones.FirstOrDefault(x => x.Name == name);
            if (drone != null)
            {
                Drones.Remove(drone);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RemoveDroneByBrand(string brand)
        {
            int n = 0;
            int count = Drones.Count;
             
            if (Drones.Any(x => x.Brand == brand))
            {
                 Drones.RemoveAll(x => x.Brand == brand);
                n = Drones.Count;
                return count - n;

            }
            else
            {
                return count;
            }
        }
        public Drone FlyDrone(string name)
        {
           List<Drone> fly = new List<Drone>();
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);

            if(drone==null)
            {
                fly.Add(drone);
                drone.Available = false;

                return null;
            }

            return drone;

        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = Drones.Where(x => x.Range >= range).ToList();
            return drones;
        }
        public string Report()
        {


            //List<Drone> unflighth = Drones.Where(x => x.Available = false).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");


            foreach (Drone drone in Drones)
            {
                if (drone.Available==false)
                {
                    sb.AppendLine(drone.ToString());

                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}

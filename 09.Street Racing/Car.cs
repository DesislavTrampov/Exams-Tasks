﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        public Car(string make,string model,string licensePlate,int horsePower,double weigth)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weigth;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public int HorsePower { get; set; }

        public double Weight { get; set; }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"License Plate: {LicensePlate}");
            sb.AppendLine($"Horse Power: {HorsePower}");
            sb.AppendLine($"Weight: {Weight}");

            return sb.ToString().TrimEnd();
        }




    }
}

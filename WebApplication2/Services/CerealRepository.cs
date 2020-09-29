using System;
using System.Collections.Generic;
using System.IO;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    public class CerealRepository : ICerealRepository
    {
        private readonly List<Cereal> Cereals = ReadCereals();

        private static List<Cereal> ReadCereals()
        {
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\cereal.csv"));
            string[] myFile = File.ReadAllLines(newPath);

            List<Cereal> cereals = new List<Cereal>();
            foreach (string line in myFile)
            {
                string[] column = line.Split(",");
                cereals.Add(new Cereal
                {
                    Name = column[0],
                    Mfr = column[1],
                    Type = column[2],
                    Calories = Convert.ToInt32(column[3]),
                    Protein = column[4],
                    Fat = column[5],
                    Sodium = column[6],
                    Fiber = column[7],
                    Carbo = column[8],
                    Sugars = column[9],
                    Potass = column[10],
                    Vitamins = column[11],
                    Shelf = column[12],
                    Weight = decimal.Parse(column[13]),
                    Cups = decimal.Parse(column[14]),
                    Rating = column[15],
                });
            }
            return cereals;
        }

        public List<Cereal> GetCereals(string sortBy)
        {
            return Cereals;
        }
    }
}
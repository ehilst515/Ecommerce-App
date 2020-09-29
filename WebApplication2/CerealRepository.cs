using ECommerceApp.Controllers;
using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ECommerceApp.Services
{
    
    public class CerealRepository : ICerealRepository
    {
        private readonly List<Cereal> Cereals = new List<Cereal>{
        };
        private static string path = Environment.CurrentDirectory;
        private static string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\cereal.csv"));
        private static string[] myFile = File.ReadAllLines(newPath);

        public List<Cereal> GetCereals(string sortBy)
        {
            foreach(string line in myFile)
            {
                string[] column = line.Split(",");
                Cereals.Add(new Cereal
                {
                    Name = column[0],
                    Mfr = column[1],
                    Type = column[2],
                    Calories = column[3],
                    Protein = column[4],
                    Fat = column[5],
                    Sodium = column[6],
                    Fiber = column[7],
                    Carbo = column[8],
                    Sugars = column[9],
                    Potass = column[10],
                    Vitamins = column[11],
                    Shelf = column[12],
                    Weight = column[13],
                    Cups = column[14],
                    Rating = column[15],
                });
            }
            return Cereals;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CarSharing_Database.ModelData;

namespace CarSharing_Database.Persistence
{
    public class FileContext
    {
        private static FileContext _instance;

        public static FileContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileContext();
                }

                return _instance;
            }
        }
        
        public IList<Vehicle> Vehicles { get; private set; }
        
        private readonly string vehicleFile = "vehicle.json";
        
        
        private FileContext()
        {
            Vehicles = File.Exists(vehicleFile) ? ReadData<Vehicle>(vehicleFile) : new List<Vehicle>();
            
        }

        private IList<T> ReadData<T>(string s)
        {
            using var jsonReader = File.OpenText(s);
            return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
        }

        public void SaveChanges()
        {
            string jsonAdults = JsonSerializer.Serialize(Vehicles, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using StreamWriter outputFile = new StreamWriter(vehicleFile, false);
            outputFile.Write(jsonAdults);
        }
    }
}
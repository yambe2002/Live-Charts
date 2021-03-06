﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace UWP.CartesianChart.Linq
{
    public static class DataBase
    {
        public static City[] Cities { get; private set; }

        public static async Task Initialize()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///cities.csv"));
            var stream = await file.OpenStreamForReadAsync();
            var reader = new StreamReader(stream);

            var read = new List<City>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    var values = line.Split(',');

                    read.Add(new City
                    {
                        Name = values[0],
                        Population = double.Parse(values[1]),
                        Area = double.Parse(values[2]),
                        Country = values[3]
                    });
                }
            }

            Cities = read.ToArray();
        }
    }
}

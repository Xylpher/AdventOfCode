using AdventOfCode.Utils;

namespace AdventOfCode2023
{
    internal class Day5 : Day
    {
        public Day5() : base(5)
        {
        }

        public override string ProblemOne()
        {
            List<long> seeds = new List<long>();

            List<Map> seedToSoil = new List<Map>();
            List<Map> soilToFertilizer = new List<Map>();
            List<Map> fertilizerToWater = new List<Map>();
            List<Map> waterToLight = new List<Map>();
            List<Map> lightToTemperature = new List<Map>();
            List<Map> temperatureToHumidity = new List<Map>();
            List<Map> humidityToLocation = new List<Map>();

            #region Fill Data

            lines.ElementAt(0).Split(':')[1].Split(" ").ToList().ForEach(x => { if (x != "") seeds.Add(long.Parse(x)); });
            int lastIndexUsed = 3;

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                seedToSoil.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                soilToFertilizer.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                fertilizerToWater.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                waterToLight.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                lightToTemperature.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                temperatureToHumidity.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                humidityToLocation.Add(new Map(line));
            }

            #endregion

            var lowestLocationNumber = long.MaxValue;

            foreach (var seed in seeds)
            {
                var seedToSoilMap = seedToSoil.Where(x => x.SourceStart < seed && (x.SourceStart + x.Range) > seed).FirstOrDefault();
                var soil = seed;
                if (seedToSoilMap != null)
                {
                    soil = seedToSoilMap.DestinationStart + (seed - seedToSoilMap.SourceStart);
                }

                var soilToFertilizerMap = soilToFertilizer.Where(x => x.SourceStart < soil && (x.SourceStart + x.Range) > soil).FirstOrDefault();
                var fertilizer = soil;
                if (soilToFertilizerMap != null)
                {
                    fertilizer = soilToFertilizerMap.DestinationStart + (soil - soilToFertilizerMap.SourceStart);
                }

                var fertilizerToWaterMap = fertilizerToWater.Where(x => x.SourceStart < fertilizer && (x.SourceStart + x.Range) > fertilizer).FirstOrDefault();
                var water = fertilizer;
                if (fertilizerToWaterMap != null)
                {
                    water = fertilizerToWaterMap.DestinationStart + (fertilizer - fertilizerToWaterMap.SourceStart);
                }

                var waterToLightMap = waterToLight.Where(x => x.SourceStart < water && (x.SourceStart + x.Range) > water).FirstOrDefault();
                var light = water;
                if (waterToLightMap != null)
                {
                    light = waterToLightMap.DestinationStart + (water - waterToLightMap.SourceStart);
                }

                var lightToTemperatureMap = lightToTemperature.Where(x => x.SourceStart < light && (x.SourceStart + x.Range) > light).FirstOrDefault();
                var temperature = light;
                if (lightToTemperatureMap != null)
                {
                    temperature = lightToTemperatureMap.DestinationStart + (light - lightToTemperatureMap.SourceStart);
                }

                var temperatureToHumidityMap = temperatureToHumidity.Where(x => x.SourceStart < temperature && (x.SourceStart + x.Range) > temperature).FirstOrDefault();
                var humidity = temperature;
                if (temperatureToHumidityMap != null)
                {
                    humidity = temperatureToHumidityMap.DestinationStart + (temperature - temperatureToHumidityMap.SourceStart);
                }

                var humidityToLocationMap = humidityToLocation.Where(x => x.SourceStart < humidity && (x.SourceStart + x.Range) > humidity).FirstOrDefault();
                var location = humidity;
                if (humidityToLocationMap != null)
                {
                    location = humidityToLocationMap.DestinationStart + (humidity - humidityToLocationMap.SourceStart);
                }

                if (location < lowestLocationNumber)
                    lowestLocationNumber = location;
            }


            return lowestLocationNumber.ToString();
        }

        public override string ProblemTwo()
        {
            //Currently bruteforcing, have to update this


            List<long> seeds = new List<long>();

            List<Map> seedToSoil = new List<Map>();
            List<Map> soilToFertilizer = new List<Map>();
            List<Map> fertilizerToWater = new List<Map>();
            List<Map> waterToLight = new List<Map>();
            List<Map> lightToTemperature = new List<Map>();
            List<Map> temperatureToHumidity = new List<Map>();
            List<Map> humidityToLocation = new List<Map>();

            #region Fill Data

            var seedData = lines.ElementAt(0).Split(':')[1].Split(" ").ToList();
            seedData.RemoveAll(x => x == "");
            for (int i = 0; i < seedData.Count(); i += 2)
            {
                var startSeed = long.Parse(seedData[i]);
                var seedAmount = long.Parse(seedData[i + 1]);
                for (int j = 0; j < seedAmount; j++)
                {
                    seeds.Add(startSeed + j);
                }
            }
            seeds = seeds.Distinct().ToList();


            int lastIndexUsed = 3;

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                seedToSoil.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                soilToFertilizer.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                fertilizerToWater.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                waterToLight.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                lightToTemperature.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                temperatureToHumidity.Add(new Map(line));
            }

            for (int i = lastIndexUsed; i < lines.Count(); i++)
            {
                var line = lines.ElementAt(i);
                if (string.IsNullOrEmpty(line))
                {
                    lastIndexUsed = i + 2;
                    break;
                }
                humidityToLocation.Add(new Map(line));
            }

            #endregion

            var lowestLocationNumber = long.MaxValue;
            var currentSeedIndex = 0;
            foreach (var seed in seeds)
            {
                var seedToSoilMap = seedToSoil.Where(x => x.SourceStart < seed && (x.SourceStart + x.Range) > seed).FirstOrDefault();
                var soil = seed;
                if (seedToSoilMap != null)
                {
                    soil = seedToSoilMap.DestinationStart + (seed - seedToSoilMap.SourceStart);
                }

                var soilToFertilizerMap = soilToFertilizer.Where(x => x.SourceStart < soil && (x.SourceStart + x.Range) > soil).FirstOrDefault();
                var fertilizer = soil;
                if (soilToFertilizerMap != null)
                {
                    fertilizer = soilToFertilizerMap.DestinationStart + (soil - soilToFertilizerMap.SourceStart);
                }

                var fertilizerToWaterMap = fertilizerToWater.Where(x => x.SourceStart < fertilizer && (x.SourceStart + x.Range) > fertilizer).FirstOrDefault();
                var water = fertilizer;
                if (fertilizerToWaterMap != null)
                {
                    water = fertilizerToWaterMap.DestinationStart + (fertilizer - fertilizerToWaterMap.SourceStart);
                }

                var waterToLightMap = waterToLight.Where(x => x.SourceStart < water && (x.SourceStart + x.Range) > water).FirstOrDefault();
                var light = water;
                if (waterToLightMap != null)
                {
                    light = waterToLightMap.DestinationStart + (water - waterToLightMap.SourceStart);
                }

                var lightToTemperatureMap = lightToTemperature.Where(x => x.SourceStart < light && (x.SourceStart + x.Range) > light).FirstOrDefault();
                var temperature = light;
                if (lightToTemperatureMap != null)
                {
                    temperature = lightToTemperatureMap.DestinationStart + (light - lightToTemperatureMap.SourceStart);
                }

                var temperatureToHumidityMap = temperatureToHumidity.Where(x => x.SourceStart < temperature && (x.SourceStart + x.Range) > temperature).FirstOrDefault();
                var humidity = temperature;
                if (temperatureToHumidityMap != null)
                {
                    humidity = temperatureToHumidityMap.DestinationStart + (temperature - temperatureToHumidityMap.SourceStart);
                }

                var humidityToLocationMap = humidityToLocation.Where(x => x.SourceStart < humidity && (x.SourceStart + x.Range) > humidity).FirstOrDefault();
                var location = humidity;
                if (humidityToLocationMap != null)
                {
                    location = humidityToLocationMap.DestinationStart + (humidity - humidityToLocationMap.SourceStart);
                }

                if (location < lowestLocationNumber)
                    lowestLocationNumber = location;

                currentSeedIndex++;
            }


            return lowestLocationNumber.ToString();
        }
    }


    internal class Map
    {
        public Map(string data)
        {
            var dataValues = data.Split(" ");
            SourceStart = long.Parse(dataValues[1]);
            DestinationStart = long.Parse(dataValues[0]);
            Range = long.Parse(dataValues[2]);
        }

        public long Range { get; set; } = -1;
        public long SourceStart { get; set; } = -1;
        public long DestinationStart { get; set; } = -1;
    }
}

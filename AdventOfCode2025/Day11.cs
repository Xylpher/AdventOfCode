using AdventOfCode.Utils;

namespace AdventOfCode2025
{
    internal class Day11 : Day
    {
        List<Device> devices = new List<Device>();
        Device startDevice;
        Dictionary<string, long> seenDevices = new Dictionary<string, long>();


        public Day11() : base(11)
        {

        }

        private void ParseInput(string startName)
        {
            seenDevices = new Dictionary<string, long>();
            devices.Add(new Device() { Name = "out" });

            foreach (var line in lines)
            {
                var d = new Device();
                var split = line.Split(':');
                d.Name = split[0];
                split[1].Trim().Split(' ').ToList().ForEach(x => d.OutputsString.Add(x));
                devices.Add(d);
            }
            startDevice = devices.Where(x => x.Name == startName).First();
            foreach (var device in devices)
                device.OutputsString.ForEach(x =>
                {
                    if (String.Compare(x, startName, true) != 0)
                        device.Outputs.Add(devices.Where(y => y.Name == x).First());
                });
        }

        public override string ProblemOne()
        {
            long result = 0;

            ParseInput("you");

            result = FindPath(startDevice);

            return result.ToString();
        }

        public override string ProblemTwo()
        {
            long result = 0;

            ParseInput("svr");

            result = FindPath(startDevice, true);

            return result.ToString();
        }

        private long FindPath(Device currentDevice, bool careP2 = false, bool visitedDac = false, bool visitedFft = false)
        {
            if (!currentDevice.Outputs.Any())
            {
                if (careP2)
                    return visitedDac && visitedFft ? 1 : 0;
                return 1;
            }


            var key = careP2 ? $"{currentDevice.Name};{visitedDac};{visitedFft}" : currentDevice.Name;
            if (seenDevices.ContainsKey(key))
                return seenDevices[key];

            if (careP2)
            {
                if (currentDevice.Name == "dac")
                    visitedDac = true;
                else if (currentDevice.Name == "fft")
                    visitedFft = true;
            }

            long pathResult = 0;

            foreach (var next in currentDevice.Outputs)
            {
                pathResult += FindPath(next, careP2, visitedDac, visitedFft);
            }

            seenDevices.Add(key, pathResult);

            return pathResult;
        }

        internal struct Device
        {
            public string Name = "";
            public List<string> OutputsString = new List<string>();
            public HashSet<Device> Outputs = new HashSet<Device>();

            public Device()
            { }
        }
    }
}



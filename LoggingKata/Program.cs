using System;
using System.Linq;
using System.IO;
using System.IO;
using System.Device.Location;
using Geolocation;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse);
			ITrackable a = null;
			ITrackable b = null;
			double distance = 0;

			foreach(var locA in locations)
			{
				var origin = new GeoCoordinate
				{
					Latitude = locA.Location.Latitude,
					Longitude = locA.Location.Longitude,
				};
				foreach (var locB in locations)
				{
					var newDistance = GeoCalculator.GetDistance(origin, destination);
					if (newDistance > distance)
					{
						a = locA;
						b = locB;
						distance = newDistance;
					}
				}
			}

			Console.WriteLine($"The two Taco Bells that are farthest apart are: {a.Name} and {b.Name}");
			Console.WriteLine($"These two locations are {distance} apart");
			Console.ReadLine(); 

            // TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
            // HINT:  You'll need two nested forloops
        }
    }
}
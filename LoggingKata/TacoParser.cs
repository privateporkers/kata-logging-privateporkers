using System;


namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

		public ITrackable Parse(string line)
		{
			logger.LogInfo("Begin parsing");

			if (string.IsNullOrEmpty(line))
			{
				logger.LogError("This Line is empty");
				return null;
			}

			var cells = line.Split(',');
			if (cells.Length < 3)
			{
				logger.LogError("That is not the correct size");
				return null;
			}

			var lon = double.Parse(cells[0]);
			var lat = double.Parse(cells[1]);
			var name = cells[2];

			try
			{
				if (lat > Point.MaxLat || lat < -Point.MaxLat)
				{
					logger.LogWarning("Latitude out of range");
					return null;
				}
				if(lon > Point.MaxLon || lon < -Point.MaxLon)
				{
					logger.LogWarning("Longitude out of range");
					return null;
				}
			}
			catch (Exception e)
			{
				logger.LogError("Something messed up with parsing");
				Console.WriteLine(e);
			}

			return new TacoBell
			{
				Location = new Point { Longitude = lon, Latitude = lat },
				Name = name
			};
            //DO not fail if one record parsing fails, return null
        }
    }
}
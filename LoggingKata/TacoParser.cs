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
                return null;
            }

            var cells = line.Split(',');
            if (cells.Length < 2)
            {
                logger.LogError("Error:");
                return null;
            }

            var lon = double.Parse(cells[0]);
            var lat = double.Parse(cells[1]);
            var name = cells[2];

            try
            {
                if (lat > Point.MaxLat || lat < -Point.MaxLat)
                {
                    return null;
                }
                if (lon > Point.MaxLon || lon < -Point.MaxLon)
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                logger.LogError("Exception");
                return null;
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
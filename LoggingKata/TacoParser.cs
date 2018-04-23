﻿namespace LoggingKata
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

            //DO not fail if one record parsing fails, return null
            var cells = line.Split(',');
            if(cells.Length < 3)
            {
                return null; //TODO Implement
            }
        }
    }
}
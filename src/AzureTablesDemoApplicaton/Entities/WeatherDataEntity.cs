using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTablesDemoApplication.Entities
{
    public class WeatherDataEntity : ITableEntity
    {

        public String PartitionKey { get; set; }  // Station Name

        public string RowKey { get; set; }        // Observation date

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public double Barometer { get; set; }

        public string WindDirection { get; set; }

        public double WindSpeed { get; set; }

        public double Precipitation { get; set; }
    }
}

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

        public String PartitionKey 
        { 
            get => StationName; 
            set => StationName = value; 
        } 

        public string RowKey 
        { 
            get => ObservationDate; 
            set => ObservationDate = value; 
        }

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }

        public string StationName { get; set; }

        public string ObservationDate { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public double Barometer { get; set; }

        public string WindDirection { get; set; }

        public double WindSpeed { get; set; }

        public double Precipitation { get; set; }
    }
}

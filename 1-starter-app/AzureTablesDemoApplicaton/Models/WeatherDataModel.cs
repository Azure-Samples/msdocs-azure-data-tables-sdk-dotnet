using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTablesDemoApplication.Models
{
    public class WeatherDataModel 
    {
        // Captures all of the weather data fields and values -- temp, humidity, wind speed, etc
        private Dictionary<string, object> _fields = new Dictionary<string, object>();

        public string StationName { get; set; }

        public string ObservationDate { get; set; }


        public object this[string key] 
        { 
            get => (_fields.ContainsKey(key)) ? _fields[key] : null; 
            set => _fields[key] = value; 
        }

        public ICollection<string> FieldNames => _fields.Keys;

        public int FieldCount => _fields.Count;


        public void Add(string key, object value)
        {
            _fields.Add(key, value);
        }


        public bool ContainsKey(string key)
        {
            return _fields.ContainsKey(key);
        }

    }
}

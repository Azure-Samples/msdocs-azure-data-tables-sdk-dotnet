using AzureTablesDemoApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTablesDemoApplication.Data
{
    public static class SampleWeatherData
    {



        public static IEnumerable<string> GetSampleCities()
        {
            return SampleData.Select(x => x.StationName).Distinct();
        }

        public static IEnumerable<WeatherInputModel> GetSampleData(string units, string city)
        {
            var cityData = (units == "US") ? SampleData.Where(x => x.StationName == city)
                : SampleData.Where(x => x.StationName == city)
                      .Select(x => new WeatherInputModel() { 
                          StationName = x.StationName,
                          ObservationDate = x.ObservationDate,
                          ObservationTime = x.ObservationTime,
                          Temperature = (x.Temperature -32) * 5f/9f,
                          Humidity = x.Humidity,
                          Barometer = x.Barometer * 33.864,
                          WindDirection = x.WindDirection,
                          WindSpeed = x.WindSpeed * 1.609,
                          Precipitation = x.Precipitation * 25.4
                      });

            return cityData;

        }







        public static WeatherInputModel[] SampleData = new WeatherInputModel[]
        {
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-01", ObservationTime = "00:00", Temperature = 72, Humidity = 82, Barometer = 29.99, WindDirection = "S", WindSpeed = 1, Precipitation = 0.01 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-01", ObservationTime = "03:00", Temperature = 70, Humidity = 87, Barometer = 29.96, WindDirection = "S", WindSpeed = 1, Precipitation = 0.14 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-01", ObservationTime = "06:00", Temperature = 68, Humidity = 84, Barometer = 29.99, WindDirection = "NE", WindSpeed = 14, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-01", ObservationTime = "09:00", Temperature = 72, Humidity = 66, Barometer = 30.02, WindDirection = "N", WindSpeed = 12, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-01", ObservationTime = "12:00", Temperature = 76, Humidity = 50, Barometer = 30.04, WindDirection = "N", WindSpeed = 16, Precipitation = 0.01 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-01", ObservationTime = "15:00", Temperature = 77, Humidity = 47, Barometer = 30.03, WindDirection = "NE", WindSpeed = 20, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-01", ObservationTime = "18:00", Temperature = 72, Humidity = 48, Barometer = 30.04, WindDirection = "NE", WindSpeed = 17, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-01", ObservationTime = "21:00", Temperature = 65, Humidity = 59, Barometer = 30.05, WindDirection = "N", WindSpeed = 14, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-02", ObservationTime = "00:00", Temperature = 63, Humidity = 65, Barometer = 30.06, WindDirection = "N", WindSpeed = 12, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-02", ObservationTime = "03:00", Temperature = 62, Humidity = 75, Barometer = 30.05, WindDirection = "N", WindSpeed = 12, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-02", ObservationTime = "06:00", Temperature = 62, Humidity = 78, Barometer = 30.08, WindDirection = "N", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-02", ObservationTime = "09:00", Temperature = 68, Humidity = 65, Barometer = 30.12, WindDirection = "N", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-02", ObservationTime = "12:00", Temperature = 71, Humidity = 53, Barometer = 30.12, WindDirection = "S", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-02", ObservationTime = "15:00", Temperature = 73, Humidity = 41, Barometer = 30.09, WindDirection = "N", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-02", ObservationTime = "18:00", Temperature = 72, Humidity = 44, Barometer = 30.06, WindDirection = "NE", WindSpeed = 10, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-02", ObservationTime = "21:00", Temperature = 66, Humidity = 54, Barometer = 30.04, WindDirection = "NE", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-03", ObservationTime = "00:00", Temperature = 63, Humidity = 70, Barometer = 30.05, WindDirection = "N", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-03", ObservationTime = "03:00", Temperature = 59, Humidity = 81, Barometer = 30.06, WindDirection = "W", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-03", ObservationTime = "06:00", Temperature = 60, Humidity = 75, Barometer = 30.06, WindDirection = "W", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-03", ObservationTime = "09:00", Temperature = 70, Humidity = 56, Barometer = 30.06, WindDirection = "W", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-03", ObservationTime = "12:00", Temperature = 80, Humidity = 51, Barometer = 30.00, WindDirection = "NW", WindSpeed = 12, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-03", ObservationTime = "15:00", Temperature = 85, Humidity = 45, Barometer = 29.96, WindDirection = "W", WindSpeed = 10, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-03", ObservationTime = "18:00", Temperature = 85, Humidity = 48, Barometer = 29.93, WindDirection = "NW", WindSpeed = 13, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-03", ObservationTime = "21:00", Temperature = 80, Humidity = 64, Barometer = 29.93, WindDirection = "W", WindSpeed = 9, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-04", ObservationTime = "00:00", Temperature = 75, Humidity = 71, Barometer = 29.94, WindDirection = "W", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-04", ObservationTime = "03:00", Temperature = 72, Humidity = 73, Barometer = 29.95, WindDirection = "W", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-04", ObservationTime = "06:00", Temperature = 70, Humidity = 79, Barometer = 29.96, WindDirection = "W", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-04", ObservationTime = "09:00", Temperature = 77, Humidity = 66, Barometer = 29.98, WindDirection = "W", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-04", ObservationTime = "12:00", Temperature = 84, Humidity = 55, Barometer = 29.96, WindDirection = "W", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-04", ObservationTime = "15:00", Temperature = 88, Humidity = 45, Barometer = 29.93, WindDirection = "SW", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-04", ObservationTime = "18:00", Temperature = 87, Humidity = 51, Barometer = 29.93, WindDirection = "W", WindSpeed = 13, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Chicago", ObservationDate = "2021-07-04", ObservationTime = "21:00", Temperature = 82, Humidity = 63, Barometer = 29.93, WindDirection = "SW", WindSpeed = 9, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-01", ObservationTime = "00:00", Temperature = 76, Humidity = 97, Barometer = 30.03, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-01", ObservationTime = "03:00", Temperature = 75, Humidity = 96, Barometer = 30.00, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-01", ObservationTime = "06:00", Temperature = 75, Humidity = 100, Barometer = 29.99, WindDirection = "N", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-01", ObservationTime = "09:00", Temperature = 81, Humidity = 85, Barometer = 30.02, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-01", ObservationTime = "12:00", Temperature = 79, Humidity = 88, Barometer = 30.03, WindDirection = "VARIABLE", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-01", ObservationTime = "15:00", Temperature = 78, Humidity = 87, Barometer = 30.00, WindDirection = "SE", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-01", ObservationTime = "18:00", Temperature = 79, Humidity = 88, Barometer = 30.00, WindDirection = "ESE", WindSpeed = 10, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-01", ObservationTime = "21:00", Temperature = 79, Humidity = 88, Barometer = 30.00, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-02", ObservationTime = "00:00", Temperature = 79, Humidity = 79, Barometer = 30.02, WindDirection = "VARIABLE", WindSpeed = 3, Precipitation = 0.03 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-02", ObservationTime = "03:00", Temperature = 79, Humidity = 94, Barometer = 29.99, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-02", ObservationTime = "06:00", Temperature = 79, Humidity = 88, Barometer = 29.99, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-02", ObservationTime = "09:00", Temperature = 79, Humidity = 88, Barometer = 30.03, WindDirection = "SW", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-02", ObservationTime = "12:00", Temperature = 87, Humidity = 64, Barometer = 30.02, WindDirection = "S", WindSpeed = 13, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-02", ObservationTime = "15:00", Temperature = 90, Humidity = 57, Barometer = 29.96, WindDirection = "VARIABLE", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-02", ObservationTime = "18:00", Temperature = 88, Humidity = 65, Barometer = 29.92, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.20 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-02", ObservationTime = "21:00", Temperature = 77, Humidity = 94, Barometer = 29.99, WindDirection = "E", WindSpeed = 6, Precipitation = 0.37 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-03", ObservationTime = "00:00", Temperature = 77, Humidity = 96, Barometer = 30.01, WindDirection = "SE", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-03", ObservationTime = "03:00", Temperature = 76, Humidity = 97, Barometer = 29.99, WindDirection = "SW", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-03", ObservationTime = "06:00", Temperature = 76, Humidity = 100, Barometer = 29.99, WindDirection = "W", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-03", ObservationTime = "09:00", Temperature = 85, Humidity = 75, Barometer = 30.01, WindDirection = "VARIABLE", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-03", ObservationTime = "12:00", Temperature = 89, Humidity = 63, Barometer = 30.02, WindDirection = "SW", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-03", ObservationTime = "15:00", Temperature = 94, Humidity = 62, Barometer = 29.97, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-03", ObservationTime = "18:00", Temperature = 91, Humidity = 57, Barometer = 29.95, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-03", ObservationTime = "21:00", Temperature = 87, Humidity = 57, Barometer = 30.01, WindDirection = "NW", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-04", ObservationTime = "00:00", Temperature = 82, Humidity = 82, Barometer = 30.01, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-04", ObservationTime = "03:00", Temperature = 80, Humidity = 100, Barometer = 29.97, WindDirection = "NW", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-04", ObservationTime = "06:00", Temperature = 80, Humidity = 90, Barometer = 29.98, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-04", ObservationTime = "09:00", Temperature = 82, Humidity = 77, Barometer = 30.01, WindDirection = "E", WindSpeed = 12, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-04", ObservationTime = "12:00", Temperature = 90, Humidity = 59, Barometer = 30.01, WindDirection = "SE", WindSpeed = 10, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-04", ObservationTime = "15:00", Temperature = 92, Humidity = 60, Barometer = 29.97, WindDirection = "E", WindSpeed = 13, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-04", ObservationTime = "18:00", Temperature = 89, Humidity = 65, Barometer = 29.95, WindDirection = "SE", WindSpeed = 10, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Miami", ObservationDate = "2021-07-04", ObservationTime = "21:00", Temperature = 82, Humidity = 82, Barometer = 29.99, WindDirection = "SE", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-01", ObservationTime = "00:00", Temperature = 89, Humidity = 39, Barometer = 28.67, WindDirection = "SE", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-01", ObservationTime = "03:00", Temperature = 88, Humidity = 40, Barometer = 28.66, WindDirection = "E", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-01", ObservationTime = "06:00", Temperature = 86, Humidity = 38, Barometer = 28.69, WindDirection = "E", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-01", ObservationTime = "09:00", Temperature = 93, Humidity = 31, Barometer = 28.72, WindDirection = "W", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-01", ObservationTime = "12:00", Temperature = 100, Humidity = 23, Barometer = 28.67, WindDirection = "W", WindSpeed = 9, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-01", ObservationTime = "15:00", Temperature = 104, Humidity = 19, Barometer = 28.58, WindDirection = "N", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-01", ObservationTime = "18:00", Temperature = 106, Humidity = 19, Barometer = 28.51, WindDirection = "W", WindSpeed = 10, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-01", ObservationTime = "21:00", Temperature = 102, Humidity = 21, Barometer = 28.55, WindDirection = "S", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-02", ObservationTime = "00:00", Temperature = 93, Humidity = 36, Barometer = 28.64, WindDirection = "NE", WindSpeed = 12, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-02", ObservationTime = "03:00", Temperature = 89, Humidity = 42, Barometer = 28.61, WindDirection = "E", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-02", ObservationTime = "06:00", Temperature = 90, Humidity = 37, Barometer = 28.66, WindDirection = "E", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-02", ObservationTime = "09:00", Temperature = 92, Humidity = 38, Barometer = 28.69, WindDirection = "W", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-02", ObservationTime = "12:00", Temperature = 96, Humidity = 32, Barometer = 28.68, WindDirection = "W", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-02", ObservationTime = "15:00", Temperature = 101, Humidity = 26, Barometer = 28.59, WindDirection = "VARIABLE", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-02", ObservationTime = "18:00", Temperature = 103, Humidity = 22, Barometer = 28.55, WindDirection = "W", WindSpeed = 10, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-02", ObservationTime = "21:00", Temperature = 98, Humidity = 25, Barometer = 28.61, WindDirection = "S", WindSpeed = 13, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-03", ObservationTime = "00:00", Temperature = 92, Humidity = 38, Barometer = 28.67, WindDirection = "SE", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-03", ObservationTime = "03:00", Temperature = 91, Humidity = 37, Barometer = 28.67, WindDirection = "E", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-03", ObservationTime = "06:00", Temperature = 88, Humidity = 42, Barometer = 28.69, WindDirection = "E", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-03", ObservationTime = "09:00", Temperature = 94, Humidity = 36, Barometer = 28.70, WindDirection = "E", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-03", ObservationTime = "12:00", Temperature = 99, Humidity = 29, Barometer = 28.68, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-03", ObservationTime = "15:00", Temperature = 104, Humidity = 22, Barometer = 28.59, WindDirection = "W", WindSpeed = 12, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-03", ObservationTime = "18:00", Temperature = 104, Humidity = 60, Barometer = 28.56, WindDirection = "W", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-03", ObservationTime = "21:00", Temperature = 81, Humidity = 77, Barometer = 28.71, WindDirection = "E", WindSpeed = 6, Precipitation = 0.21 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-04", ObservationTime = "00:00", Temperature = 81, Humidity = 72, Barometer = 28.73, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.05 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-04", ObservationTime = "03:00", Temperature = 81, Humidity = 72, Barometer = 28.70, WindDirection = "E", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-04", ObservationTime = "06:00", Temperature = 81, Humidity = 74, Barometer = 28.72, WindDirection = "E", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-04", ObservationTime = "09:00", Temperature = 86, Humidity = 70, Barometer = 28.74, WindDirection = "E", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-04", ObservationTime = "12:00", Temperature = 94, Humidity = 38, Barometer = 28.72, WindDirection = "E", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-04", ObservationTime = "15:00", Temperature = 99, Humidity = 31, Barometer = 28.64, WindDirection = "N", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-04", ObservationTime = "18:00", Temperature = 102, Humidity = 26, Barometer = 28.59, WindDirection = "S", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Phoenix", ObservationDate = "2021-07-04", ObservationTime = "21:00", Temperature = 98, Humidity = 31, Barometer = 28.60, WindDirection = "S", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-01", ObservationTime = "00:00", Temperature = 52, Humidity = 77, Barometer = 29.96, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-01", ObservationTime = "03:00", Temperature = 48, Humidity = 86, Barometer = 29.96, WindDirection = "SSW", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-01", ObservationTime = "06:00", Temperature = 48, Humidity = 86, Barometer = 29.95, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-01", ObservationTime = "09:00", Temperature = 56, Humidity = 75, Barometer = 29.95, WindDirection = "SW", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-01", ObservationTime = "12:00", Temperature = 59, Humidity = 64, Barometer = 29.93, WindDirection = "NW", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-01", ObservationTime = "15:00", Temperature = 61, Humidity = 64, Barometer = 29.87, WindDirection = "WNW", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-01", ObservationTime = "18:00", Temperature = 63, Humidity = 65, Barometer = 29.85, WindDirection = "NNW", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-01", ObservationTime = "21:00", Temperature = 68, Humidity = 37, Barometer = 29.55, WindDirection = "SSE", WindSpeed = 13, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-02", ObservationTime = "00:00", Temperature = 63, Humidity = 50, Barometer = 29.81, WindDirection = "SE", WindSpeed = 15, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-02", ObservationTime = "03:00", Temperature = 59, Humidity = 62, Barometer = 29.80, WindDirection = "SE", WindSpeed = 15, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-02", ObservationTime = "06:00", Temperature = 56, Humidity = 72, Barometer = 29.79, WindDirection = "SSE", WindSpeed = 15, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-02", ObservationTime = "09:00", Temperature = 56, Humidity = 84, Barometer = 29.82, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-02", ObservationTime = "12:00", Temperature = 60, Humidity = 60, Barometer = 29.85, WindDirection = "SE", WindSpeed = 16, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-02", ObservationTime = "15:00", Temperature = 63, Humidity = 50, Barometer = 29.86, WindDirection = "SE", WindSpeed = 18, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-02", ObservationTime = "18:00", Temperature = 64, Humidity = 45, Barometer = 29.87, WindDirection = "SE", WindSpeed = 21, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-02", ObservationTime = "21:00", Temperature = 60, Humidity = 51, Barometer = 29.91, WindDirection = "SSE", WindSpeed = 15, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-03", ObservationTime = "00:00", Temperature = 54, Humidity = 66, Barometer = 29.98, WindDirection = "WSW", WindSpeed = 13, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-03", ObservationTime = "03:00", Temperature = 53, Humidity = 69, Barometer = 30.02, WindDirection = "W", WindSpeed = 12, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-03", ObservationTime = "06:00", Temperature = 50, Humidity = 83, Barometer = 30.05, WindDirection = "CALM", WindSpeed = 0, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-03", ObservationTime = "09:00", Temperature = 51, Humidity = 86, Barometer = 30.07, WindDirection = "SE", WindSpeed = 3, Precipitation = 0.05 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-03", ObservationTime = "12:00", Temperature = 52, Humidity = 83, Barometer = 30.09, WindDirection = "NE", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-03", ObservationTime = "15:00", Temperature = 54, Humidity = 69, Barometer = 30.09, WindDirection = "NW", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-03", ObservationTime = "18:00", Temperature = 56, Humidity = 64, Barometer = 30.09, WindDirection = "WNW", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-03", ObservationTime = "21:00", Temperature = 55, Humidity = 67, Barometer = 30.10, WindDirection = "W", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-04", ObservationTime = "00:00", Temperature = 53, Humidity = 74, Barometer = 30.11, WindDirection = "W", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-04", ObservationTime = "03:00", Temperature = 52, Humidity = 74, Barometer = 30.11, WindDirection = "SSW", WindSpeed = 3, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-04", ObservationTime = "06:00", Temperature = 51, Humidity = 77, Barometer = 30.11, WindDirection = "W", WindSpeed = 7, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-04", ObservationTime = "09:00", Temperature = 53, Humidity = 77, Barometer = 30.11, WindDirection = "VARIABLE", WindSpeed = 6, Precipitation = 0.05 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-04", ObservationTime = "12:00", Temperature = 58, Humidity = 65, Barometer = 30.09, WindDirection = "VARIABLE", WindSpeed = 5, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-04", ObservationTime = "15:00", Temperature = 61, Humidity = 58, Barometer = 30.07, WindDirection = "WNW", WindSpeed = 8, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-04", ObservationTime = "18:00", Temperature = 63, Humidity = 52, Barometer = 30.03, WindDirection = "W", WindSpeed = 6, Precipitation = 0.00 },
            new WeatherInputModel() { StationName = "Anchorage", ObservationDate = "2021-07-04", ObservationTime = "21:00", Temperature = 62, Humidity = 60, Barometer = 30.01, WindDirection = "NW", WindSpeed = 3, Precipitation = 0.00 },
        };


    }



    


}

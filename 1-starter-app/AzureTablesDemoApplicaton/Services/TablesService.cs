using AzureTablesDemoApplication.Entities;
using AzureTablesDemoApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTablesDemoApplication.Services
{
    public class TablesService
    {

        public TablesService()
        {
            
        }


        public string[] EXCLUDE_TABLE_ENTITY_KEYS = { "PartitionKey", "RowKey", "odata.etag", "Timestamp" };



        public IEnumerable<WeatherDataModel> GetAllRows()
        {
            return null;
        }


        public IEnumerable<WeatherDataModel> GetFilteredRows(FilterResultsInputModel inputModel)
        {
            return null;
        }


        public IEnumerable<WeatherDataModel> MapTableEntityToWeatherDataModel()
        {
            return null;
        }



        public void InsertTableEntity(WeatherInputModel model)
        {

        }


        public void UpsertTableEntity(WeatherInputModel model)
        {

        }


        public void InsertCustomEntity(WeatherInputModel model)
        {

        }


        public void UpsertCustomEntity(WeatherInputModel model)
        {

        }


        public void InsertExpandableData(ExpandableWeatherObject weatherObject)
        {

        }


        public void UpsertExpandableData(ExpandableWeatherObject weatherObject)
        {

        }

        public void RemoveEntity(string partitionKey, string rowKey)
        {

        }


        public void InsertBulkData(IEnumerable<WeatherInputModel> items)
        {

        }


        public void UpdateEntity(UpdateWeatherObject weatherObject)
        {

        }

    }
}

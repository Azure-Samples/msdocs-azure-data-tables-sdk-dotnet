using Azure;
using Azure.Data.Tables;
using AzureTablesDemoApplication.Data;
using AzureTablesDemoApplication.Entities;
using AzureTablesDemoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureTablesDemoApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private TableClient _tableClient;

        public string[] EXCLUDE_TABLE_ENTITY_KEYS = { "PartitionKey", "RowKey", "odata.etag", "Timestamp" };

        public string[] EXCLUDE_FORM_KEYS = { "stationName", "observationDate", "observationTime", "__RequestVerificationToken" };


        public IndexModel(ILogger<IndexModel> logger, TableClient tableClient)
        {
            _logger = logger;
            _tableClient = tableClient;
        }


        public IEnumerable<string> ColumnNames { get; set; }
        public Pageable<TableEntity> WeatherObservations { get; set; }

        public void OnGet()
        {
            var entities = _tableClient.Query<TableEntity>();

            ColumnNames = entities.SelectMany(e => e.Keys).Distinct().Where(key => !EXCLUDE_TABLE_ENTITY_KEYS.Contains(key));
            WeatherObservations = entities;


        }



        public IActionResult OnPostInsertTableEntity(WeatherInputModel model)
        {
            TableEntity entity = new TableEntity();
            entity.PartitionKey = model.StationName;
            entity.RowKey = $"{model.ObservationDate} {model.ObservationTime}";

            // The other values are added like a items to a dictionary
            entity["Temperature"] = model.Temperature;
            entity["Humidity"] = model.Humidity;
            entity["Barometer"] = model.Barometer;
            entity["WindDirection"] = model.WindDirection;
            entity["WindSpeed"] = model.WindSpeed;
            entity["Precipitation"] = model.Precipitation;

            _tableClient.AddEntity(entity);

            return RedirectToPage("index", "Get");
        }

        public IActionResult OnPostUpsertTableEntity(WeatherInputModel model)
        {
            TableEntity entity = new TableEntity();
            entity.PartitionKey = model.StationName;
            entity.RowKey = $"{model.ObservationDate} {model.ObservationTime}";

            // The other values are added like a items to a dictionary
            entity["Temperature"] = model.Temperature;
            entity["Humidity"] = model.Humidity;
            entity["Barometer"] = model.Barometer;
            entity["WindDirection"] = model.WindDirection;
            entity["WindSpeed"] = model.WindSpeed;
            entity["Precipitation"] = model.Precipitation;

            _tableClient.AddEntity(entity);

            return RedirectToPage("index", "Get");
        }



        public IActionResult OnPostInsertCustomEntity(WeatherInputModel model)
        {
            WeatherDataEntity customEntity = new WeatherDataEntity();
            customEntity.PartitionKey = model.StationName;
            customEntity.RowKey = $"{model.ObservationDate} {model.ObservationTime}";

            // The remaining values are strongly typed properties on the custom entity type
            customEntity.Temperature = model.Temperature;
            customEntity.Humidity = model.Humidity;
            customEntity.Barometer = model.Barometer;
            customEntity.WindDirection = model.WindDirection;
            customEntity.WindSpeed = model.WindSpeed;
            customEntity.Precipitation = model.Precipitation;


            _tableClient.AddEntity(customEntity);

            return RedirectToPage("index", "Get");
        }

        public IActionResult OnPostUpsertCustomEntity(WeatherInputModel model)
        {
            WeatherDataEntity customEntity = new WeatherDataEntity();
            customEntity.PartitionKey = model.StationName;
            customEntity.RowKey = $"{model.ObservationDate} {model.ObservationTime}";

            // The remaining values are strongly typed properties on the custom entity type
            customEntity.Temperature = model.Temperature;
            customEntity.Humidity = model.Humidity;
            customEntity.Barometer = model.Barometer;
            customEntity.WindDirection = model.WindDirection;
            customEntity.WindSpeed = model.WindSpeed;
            customEntity.Precipitation = model.Precipitation;

            _tableClient.AddEntity(customEntity);

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostInsertExpandableData(ExpandableWeatherInputModel model)
        {
            TableEntity entity = new TableEntity();
            entity.PartitionKey = model.StationName;
            entity.RowKey = $"{model.ObservationDate} {model.ObservationTime}";

            // Get the keys to the form, but remove the ones we have already handled
            var dataKeys = Request.Form.Keys.Where(key => !EXCLUDE_FORM_KEYS.Contains(key));           
            foreach (var key in dataKeys)
            {
                var value = Request.Form[key].First();

                if (Double.TryParse(value, out double number))
                    entity[key] = value;
                else
                    entity[key] = value;
            }
            _tableClient.AddEntity(entity);

            return RedirectToPage("index", "Get");
        }

        public IActionResult OnPostUpsertExpandableData(ExpandableWeatherInputModel model)
        {
            TableEntity entity = new TableEntity();
            entity.PartitionKey = model.StationName;
            entity.RowKey = $"{model.ObservationDate} {model.ObservationTime}";

            // Get the keys to the form, but remove the ones we have already handled
            var dataKeys = Request.Form.Keys.Where(key => !EXCLUDE_FORM_KEYS.Contains(key));
            foreach (var key in dataKeys)
            {
                var value = Request.Form[key].First();

                if (Double.TryParse(value, out double number))
                    entity[key] = value;
                else
                    entity[key] = value;
            }
            _tableClient.AddEntity(entity);

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostRemoveEntity(string partitionKey, string rowKey)
        {
            _tableClient.DeleteEntity(partitionKey, rowKey);            

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostInsertBulkData(string units, string city)
        {
            var bulkData = SampleWeatherData.GetSampleData(units, city);

            var transactionActions = bulkData.Select(item => new TableTransactionAction(TableTransactionActionType.Add, item));
            var response = _tableClient.SubmitTransaction(transactionActions);

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostUpdateEntity(string partitionKey, string rowKey)
        {
            TableEntity entity = _tableClient.GetEntity<TableEntity>(partitionKey, rowKey).Value;
            
            // Get the keys to the form, but remove the ones we have already handled
            var dataKeys = Request.Form.Keys.Where(key => !(new string[] { "PartitionKey", "RowKey", "__RequestVerificationToken" }).Contains(key));
            foreach (var key in dataKeys)
            {
                var value = Request.Form[key].First();

                if (Double.TryParse(value, out double number))
                    entity[key] = value;
                else
                    entity[key] = value;
            }
            _tableClient.UpdateEntity(entity, ETag.All );

            return RedirectToPage("index", "Get");
        }


    }
}

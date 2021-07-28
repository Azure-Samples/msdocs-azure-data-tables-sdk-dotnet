using Azure;
using Azure.Data.Tables;
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

        public TablesService(TableClient tableClient)
        {
            _tableClient = tableClient;
        }

        private TableClient _tableClient;

        public string[] EXCLUDE_TABLE_ENTITY_KEYS = { "PartitionKey", "RowKey", "odata.etag", "Timestamp" };



        public IEnumerable<WeatherDataModel> GetAllRows()
        {
            Pageable<TableEntity> entities = _tableClient.Query<TableEntity>();

            return MapTableEntityToWeatherDataModel(entities);
        }


        public IEnumerable<WeatherDataModel> GetFilteredRows(FilterResultsInputModel inputModel)
        {
            List<string> filters = new List<string>();

            if (!String.IsNullOrEmpty(inputModel.PartitionKey))
                filters.Add($"PartitionKey eq '{inputModel.PartitionKey}'");
            if (!String.IsNullOrEmpty(inputModel.RowKeyDateStart) && !String.IsNullOrEmpty(inputModel.RowKeyTimeStart))
                filters.Add($"RowKey ge '{inputModel.RowKeyDateStart} {inputModel.RowKeyTimeStart}'");
            if (!String.IsNullOrEmpty(inputModel.RowKeyDateEnd) && !String.IsNullOrEmpty(inputModel.RowKeyTimeEnd))
                filters.Add($"RowKey le '{inputModel.RowKeyDateEnd} {inputModel.RowKeyTimeEnd}'");
            if (inputModel.MinTemperature.HasValue)
                filters.Add($"Temperature ge {inputModel.MinTemperature.Value}");
            if (inputModel.MaxTemperature.HasValue)
                filters.Add($"Temperature le {inputModel.MaxTemperature.Value}");
            if (inputModel.MinPrecipitation.HasValue)
                filters.Add($"Precipitation ge {inputModel.MinTemperature.Value}");
            if (inputModel.MaxPrecipitation.HasValue)
                filters.Add($"Precipitation le {inputModel.MaxTemperature.Value}");

            string filter = String.Join(" and ", filters);
            Pageable<TableEntity> entities = _tableClient.Query<TableEntity>(filter);

            return MapTableEntityToWeatherDataModel(entities);
        }


        public IEnumerable<WeatherDataModel> MapTableEntityToWeatherDataModel(Pageable<TableEntity> entities)
        {
            foreach (var entity in entities)
            {
                WeatherDataModel observation = new WeatherDataModel();
                observation.StationName = entity.PartitionKey;
                observation.ObservationDate = entity.RowKey;

                var measurements = entity.Keys.Where(key => !EXCLUDE_TABLE_ENTITY_KEYS.Contains(key));
                foreach (var key in measurements)
                {
                    observation[key] = entity[key];
                }
                yield return observation;
            }
        }



        public void InsertTableEntity(WeatherInputModel model)
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
        }


        public void UpsertTableEntity(WeatherInputModel model)
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

            _tableClient.UpsertEntity(entity);
        }


        public void InsertCustomEntity(WeatherInputModel model)
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
        }


        public void UpsertCustomEntity(WeatherInputModel model)
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

            _tableClient.UpsertEntity(customEntity);
        }


        public void InsertExpandableData(string partitionKey, string rowKey, IDictionary<string, string> fields)
        {
            TableEntity entity = new TableEntity();
            entity.PartitionKey = partitionKey;
            entity.RowKey = rowKey;

            foreach (string fieldName in fields.Keys)
            {
                var value = fields[fieldName];
                
                if (Double.TryParse(value, out double number))
                    entity[fieldName] = number;
                else
                    entity[fieldName] = value;
            }
            _tableClient.AddEntity(entity);
        }


        public void UpsertExpandableData(string partitionKey, string rowKey, IDictionary<string, string> fields)
        {
            TableEntity entity = new TableEntity();
            entity.PartitionKey = partitionKey;
            entity.RowKey = rowKey;

            foreach (string fieldName in fields.Keys)
            {
                var value = fields[fieldName];

                if (Double.TryParse(value, out double number))
                    entity[fieldName] = number;
                else
                    entity[fieldName] = value;
            }
            _tableClient.UpsertEntity(entity);
        }

        public void RemoveEntity(string partitionKey, string rowKey)
        {
            _tableClient.DeleteEntity(partitionKey, rowKey);           
        }


        public void InsertBulkData(IEnumerable<WeatherInputModel> items)
        {
            // First convert the incoming objects to TableEntities
            IEnumerable<TableEntity> entities = items.Select(item =>
            {
                var entity = new TableEntity(item.StationName, item.ObservationDate);
                entity["Temperature"] = item.Temperature;
                entity["Humidity"] = item.Humidity;
                entity["Barometer"] = item.Barometer;
                entity["WindDirection"] = item.WindDirection;
                entity["WindSpeed"] = item.WindSpeed;
                entity["Precipitation"] = item.Precipitation;

                return entity;
            });
            
            // Now wrap each TableEntity in a TableTransactionAction object
             var transactionActions = entities.Select(entity => new TableTransactionAction(TableTransactionActionType.Add, entity));

            _tableClient.SubmitTransaction(transactionActions);
        }


        public void UpdateEntity(string partitionKey, string rowKey, IDictionary<string, string> fields)
        {
            // Use the partition key and row key to get the entity
            TableEntity entity = _tableClient.GetEntity<TableEntity>(partitionKey, rowKey).Value;

            foreach (string fieldName in fields.Keys)
            {
                var value = fields[fieldName];

                if (Double.TryParse(value, out double number))
                    entity[fieldName] = number;
                else
                    entity[fieldName] = value;
            }

            _tableClient.UpdateEntity(entity, ETag.All);
        }

    }
}

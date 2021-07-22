using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using AzureTablesDemoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AzureTablesDemoApplication.Pages
{
    public class FilterResultsModel : PageModel
    {
        private readonly ILogger<FilterResultsModel> _logger;
        private TableClient _tableClient;

        public string[] EXCLUDE_TABLE_ENTITY_KEYS = { "PartitionKey", "RowKey", "odata.etag", "Timestamp" };


        public FilterResultsModel(ILogger<FilterResultsModel> logger, TableClient tableClient)
        {
            _logger = logger;
            _tableClient = tableClient;
        }


        public void OnGet(FilterResultsInputModel inputModel)
        {
            List<string> filters = new List<string>();

            if (!String.IsNullOrEmpty(inputModel.PartitionKey))
                filters.Add($"PartitionKey eq '{inputModel.PartitionKey}'");
            if (!String.IsNullOrEmpty(inputModel.RowKeyDateStart) && !String.IsNullOrEmpty(inputModel.RowKeyTimeStart))
                filters.Add($"RowKey ge '{inputModel.RowKeyDateStart} {inputModel.RowKeyTimeStart}'");
            if (!String.IsNullOrEmpty(inputModel.RowKeyDateEnd) && !String.IsNullOrEmpty(inputModel.RowKeyTimeEnd))
                filters.Add($"RowKey le '{inputModel.RowKeyDateEnd} {inputModel.RowKeyTimeEnd}'");
            if (inputModel.MinTemperature.HasValue )
                filters.Add($"Temperature ge {inputModel.MinTemperature.Value}");
            if (inputModel.MaxTemperature.HasValue)
                filters.Add($"Temperature le {inputModel.MaxTemperature.Value}");
            if (inputModel.MinPrecipitation.HasValue)
                filters.Add($"Precipitation ge {inputModel.MinTemperature.Value}");
            if (inputModel.MaxPrecipitation.HasValue)
                filters.Add($"Precipitation le {inputModel.MaxTemperature.Value}");

            string filter = String.Join(" and ", filters);
            var entities = _tableClient.Query<TableEntity>(filter);

            ColumnNames = entities.SelectMany(e => e.Keys).Distinct().Where(key => !EXCLUDE_TABLE_ENTITY_KEYS.Contains(key));
            WeatherObservations = entities;
        }


        public IEnumerable<string> ColumnNames { get; set; }
        public Pageable<TableEntity> WeatherObservations { get; set; }


        //public IActionResult OnGetFilterResults(FilterResultsInputModel inputModel)
        //{
        //    var filterExpressions = new List<Expression<Func<TableEntity, bool>>>();

        //    if ( !String.IsNullOrEmpty(inputModel.PartitionKey) )
        //    {
        //        Expression<Func<TableEntity, bool>> partitionKeyFilterExpression = (entity) => entity.PartitionKey == inputModel.PartitionKey;
        //        filterExpressions.Add(partitionKeyFilterExpression);
        //    }

        //    Expression<Func<TableEntity, bool>> filter = (entity) => entity.PartitionKey == "Madison";

        //    _tableClient.Query<TableEntity>(e => e.PartitionKey == "Chicago");
        //    _tableClient.Query<TableEntity>(filter);


        //    return new PageResult();
        //}


        //private Expression<Func<TableEntity, bool>> CreateFilterExpression(Func<TableEntity, bool> filter) => filter;

    //                {
    //            Expression<Func<TableEntity, bool>> filter = (entity) => entity.PartitionKey == stationName;
    //    var entities = _tableClient.Query<TableEntity>(filter);

    //    ColumnNames = entities.SelectMany(e => e.Keys).Distinct().Where(key => !EXCLUDE_TABLE_ENTITY_KEYS.Contains(key));
    //    WeatherObservations = entities;
    //        }
    //        else
    //        {
    //            var entities = _tableClient.Query<TableEntity>();

    //ColumnNames = entities.SelectMany(e => e.Keys).Distinct().Where(key => !EXCLUDE_TABLE_ENTITY_KEYS.Contains(key));
    //WeatherObservations = entities;
    //        }

    }
}

using AzureTablesDemoApplication.Data;
using AzureTablesDemoApplication.Models;
using AzureTablesDemoApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTablesDemoApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private TablesService _tablesService;


        public string[] EXCLUDE_FORM_KEYS = { "stationName", "observationDate", "observationTime", "__RequestVerificationToken" };


        public IndexModel(ILogger<IndexModel> logger, TablesService tablesService)
        {
            _logger = logger;
            _tablesService = tablesService;
        }


        public IEnumerable<string> FieldNames { get; set; }
        public IEnumerable<WeatherDataModel> WeatherObservations { get; set; }


        public void OnGet()
        {
            WeatherObservations = _tablesService.GetAllRows();

            FieldNames = WeatherObservations.SelectMany(e => e.PropertyNames).Distinct();           
        }


        public IActionResult OnPostInsertTableEntity(WeatherInputModel model)
        {
            _tablesService.InsertTableEntity(model);

            return RedirectToPage("index", "Get");
        }

        public IActionResult OnPostUpsertTableEntity(WeatherInputModel model)
        {
            _tablesService.UpsertTableEntity(model);

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostInsertCustomEntity(WeatherInputModel model)
        {
            _tablesService.InsertCustomEntity(model);

            return RedirectToPage("index", "Get");
        }

        public IActionResult OnPostUpsertCustomEntity(WeatherInputModel model)
        {
            _tablesService.UpsertCustomEntity(model);

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostInsertExpandableData(ExpandableWeatherInputModel model)
        {
            // The station name (partition key) and date and time elements are in the model object
            string partitionKey = model.StationName;
            string rowKey = $"{model.ObservationDate} {model.ObservationTime}";

            // The rest of the properties and values are in the form.  But we want to exclude the elements we
            // already have from the model and the __RequestVerificationToken when we build our dictionary
            var properties = Request.Form.Keys.Where(key => !EXCLUDE_FORM_KEYS.Contains(key))
                .Select(key => new KeyValuePair<string, string>(key, Request.Form[key].First()))
                .ToDictionary(item => item.Key, item => item.Value);

            _tablesService.InsertExpandableData(partitionKey, rowKey, properties);

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostUpsertExpandableData(ExpandableWeatherInputModel model)
        {
            // The station name (partition key) and date and time elements are in the model object
            string partitionKey = model.StationName;
            string rowKey = $"{model.ObservationDate} {model.ObservationTime}";

            // The rest of the properties and values are in the form.  But we want to exclude the elements we
            // already have from the model and the __RequestVerificationToken when we build our dictionary
            var properties = Request.Form.Keys.Where(key => !EXCLUDE_FORM_KEYS.Contains(key))
                .Select(key => new KeyValuePair<string, string>(key, Request.Form[key].First()))
                .ToDictionary(item => item.Key, item => item.Value);

            _tablesService.UpsertExpandableData(partitionKey, rowKey, properties);

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostRemoveEntity(string stationName, string observationDate)
        {
            _tablesService.RemoveEntity(stationName, observationDate);            

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostInsertBulkData(string units, string city)
        {
            var bulkData = SampleWeatherData.GetSampleData(units, city);

            _tablesService.InsertBulkData(bulkData);

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostUpdateEntity(string stationName, string observationDate)
        {
            // The partition key (stationName) and row key (observationDate) are passed as parameters but
            // to get the rest of the properties, we have to extract them from the from data (ignoring properties
            // we already have and __RequestVerificationToken when we build our dictionary)          
            var properties = Request.Form.Keys.Where(key => !EXCLUDE_FORM_KEYS.Contains(key))
                .Select(key => new KeyValuePair<string, string>(key, Request.Form[key].First()))
                .ToDictionary(item => item.Key, item => item.Value);

            _tablesService.UpdateEntity(stationName, observationDate, properties);

            return RedirectToPage("index", "Get");
        }


    }
}

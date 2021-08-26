using AzureTablesDemoApplication.Data;
using AzureTablesDemoApplication.Entities;
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


        public string[] EXCLUDE_FORM_KEYS = { "stationName", "observationDate", "observationTime", "etag", "__RequestVerificationToken" };


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
            ExpandableWeatherObject weatherObject = new ExpandableWeatherObject();
            weatherObject.StationName = model.StationName;
            weatherObject.ObservationDate = $"{model.ObservationDate} {model.ObservationTime}";

            // The rest of the properties and values are in the form.  But we want to exclude the elements we
            // already have from the model and the __RequestVerificationToken when we build our dictionary
            var propertyNames = Request.Form.Keys.Where(key => !EXCLUDE_FORM_KEYS.Contains(key));
            foreach (string name in propertyNames)
            {
                string value = Request.Form[name].First();

                if (Double.TryParse(value, out double number))
                    weatherObject[name] = number;
                else
                    weatherObject[name] = value;
            }

            _tablesService.InsertExpandableData(weatherObject);

            return RedirectToPage("index", "Get");
        }


        public IActionResult OnPostUpsertExpandableData(ExpandableWeatherInputModel model)
        {
            ExpandableWeatherObject weatherObject = new ExpandableWeatherObject();
            weatherObject.StationName = model.StationName;
            weatherObject.ObservationDate = $"{model.ObservationDate} {model.ObservationTime}";

            // The rest of the properties and values are in the form.  But we want to exclude the elements we
            // already have from the model and the __RequestVerificationToken when we build our dictionary
            var propertyNames = Request.Form.Keys.Where(key => !EXCLUDE_FORM_KEYS.Contains(key));
            foreach (string name in propertyNames)
            {
                string value = Request.Form[name].First();

                if (Double.TryParse(value, out double number))
                    weatherObject[name] = number;
                else
                    weatherObject[name] = value;
            }

            _tablesService.UpsertExpandableData(weatherObject);

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


        public IActionResult OnPostUpdateEntity(string stationName, string observationDate, string etag)
        {
            UpdateWeatherObject weatherObject = new UpdateWeatherObject();
            weatherObject.StationName = stationName;
            weatherObject.ObservationDate = observationDate;
            weatherObject.Etag = etag;

            // The rest of the properties and values are in the form.  But we want to exclude the elements we
            // already have from the model and the __RequestVerificationToken when we build our dictionary
            var propertyNames = Request.Form.Keys.Where(key => !EXCLUDE_FORM_KEYS.Contains(key));
            foreach (string name in propertyNames)
            {
                string value = Request.Form[name].First();

                if (Double.TryParse(value, out double number))
                    weatherObject[name] = number;
                else
                    weatherObject[name] = value;
            }

            _tablesService.UpdateEntity(weatherObject);

            return RedirectToPage("index", "Get");
        }


    }
}

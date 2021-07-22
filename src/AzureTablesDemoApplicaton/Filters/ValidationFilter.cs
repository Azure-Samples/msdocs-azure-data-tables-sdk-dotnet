using AzureTablesDemoApplication.Models;
using AzureTablesDemoApplication.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTablesDemoApplication.Filters
{
    public class ValidationFilter : IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {

        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new MessageModel() { Level = MessageLevel.Danger, Message = e.Value.Errors.First().ErrorMessage })
                    .ToArray();
                ((PageModel)context.HandlerInstance).TempData.Put<MessageModel[]>("errors", errors);
                var name = context.ActionDescriptor.Endpoint.DisplayName;
                context.Result = new RedirectToPageResult(context.ActionDescriptor.Endpoint.DisplayName, new { });
            }            
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            
        }

    }
}

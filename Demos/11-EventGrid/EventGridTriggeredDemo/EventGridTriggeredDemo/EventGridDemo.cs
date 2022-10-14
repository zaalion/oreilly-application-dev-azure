// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace EventGridTriggeredDemo
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-event-grid?tabs=in-process%2Cextensionv3&pivots=programming-language-csharp
    /// https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-event-grid-trigger?tabs=in-process%2Cextensionv3&pivots=programming-language-csharp    /// 
    /// </summary>
    public static class EventGridDemo
    {
        [FunctionName("EventGridDemo")]
        public static void Run([EventGridTrigger]EventGridEvent eventGridEvent, ILogger log)
        {
            // The Event Grid payload
            string payloadStr = JsonConvert.SerializeObject(eventGridEvent.Data);

            log.LogInformation("Recieved event from Event Grid: {payloadStr}", payloadStr);
        }
    }
}
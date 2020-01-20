using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ExpressionTree.Proxy
{
    public class BaseProxy
    {
        protected readonly HttpClient client;        
        protected readonly string eventId;
        protected BaseProxy(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            this.client = client;
            client.DefaultRequestHeaders.Clear();            
            eventId = httpContextAccessor.HttpContext.Items[Constants.eventId]?.ToString();
        }
        protected async Task AddCustomHeader(string value)
        {            
            
        }
        protected void AddRequiredHeaders(IHeaderInfo headers)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Remove(Constants.adpMessageId);
            client.DefaultRequestHeaders.Remove(Constants.PlanNumber);
            client.DefaultRequestHeaders.Remove(Constants.SmartFormCaseId);
            client.DefaultRequestHeaders.Remove(Constants.FileName);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.Media_Type_Json));
            client.DefaultRequestHeaders.Add(Constants.adpMessageId, eventId);
            client.DefaultRequestHeaders.Add(Constants.PlanNumber, headers.PlanNumber);
            client.DefaultRequestHeaders.Add(Constants.SmartFormCaseId, headers.SmartFormCaseId);
            client.DefaultRequestHeaders.Add(Constants.FileName, headers.FileName);

        }
    }
}

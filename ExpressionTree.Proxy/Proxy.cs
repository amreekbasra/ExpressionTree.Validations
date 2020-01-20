using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree.Proxy
{
    public class Proxy : BaseProxy
    {

        //private readonly ILogger<VestingProxy> logger;
        
        public Proxy(HttpClient httpClient,  IHttpContextAccessor httpContextAccessor)
            : base(httpClient, httpContextAccessor, oAuthService)
        {
           

            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri("");
#if DEBUG
            client.BaseAddress = new Uri(@"http://localhost:28987/api/v1/");
#endif
           
        }
        private new async Task AddRequiredHeaders(IHeaderInfo headers)
        {            
            base.AddRequiredHeaders(headers);
        }
        public async Task<string> Ping()
        {
            return await client.GetStringAsync("ping");
        }

        public async Task<bool> Update(object obj, IHeaderInfo headerInfo)
        {
          //  Func<Task<bool>> func = async () =>
          //  {
          //      await AddRequiredHeaders(headerInfo);
          //     // var response = await client.PutAsync("", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, Constants.Media_Type_Json));
          //     // return response.StatusCode == HttpStatusCode.OK;
          //  };
          //// return await LogExecutionTimeUtil.Runner(logger, func);
        }
    }
}

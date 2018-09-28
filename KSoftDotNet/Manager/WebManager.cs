using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KSoftDotNet.Interfaces;
using KSoftDotNet.Model.Web;

namespace KSoftDotNet.Manager
{
    internal class WebManager : IWebManager
    {
        HttpClient httpClient = new HttpClient();
        public async Task<Result> GetData(Uri uri)
        {
            try
            {
                Result result = new Result(false, "");
                var response = await httpClient.GetAsync(uri);
                var responseContent = await response.Content.ReadAsStringAsync();
                result.IsSuccess = response.IsSuccessStatusCode;
                result.ResultJson = responseContent;
                return result;
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }

        }
        public void SetToken(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("NANI" + token);
        }
    }
}

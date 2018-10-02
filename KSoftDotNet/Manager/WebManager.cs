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
        private bool _first = true;
        HttpClient httpClient = new HttpClient();
        public async Task<Result> GetData(Uri uri, string token)
        {
            try
            {
                Result result = new Result(false, "");
                if (_first)
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"NANI {token}");
                    _first = false;
                }
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
        public async Task<Result> PostData(Uri uri, HttpContent content, string token)
        {
            try
            {
                Result result = new Result(false, "");
                if (_first)
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"NANI {token}");
                    _first = false;
                }
                var response = await httpClient.PostAsync(uri, content);
                var responseContent = await response.Content.ReadAsStringAsync();
                result.IsSuccess = response.IsSuccessStatusCode;
                result.ResultJson = responseContent;
                return result;
            }
            catch (Exception e)
            {
                return new Result(false, e.Message);
            }
        }
    }
}

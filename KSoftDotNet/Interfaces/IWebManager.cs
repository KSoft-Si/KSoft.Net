using KSoftDotNet.Model.Web;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KSoftDotNet.Interfaces
{
    internal interface IWebManager
    {
        Task<Result> GetData(Uri uri, string token);
        Task<Result> PostData(Uri uri, HttpContent content, string token);
    }
}
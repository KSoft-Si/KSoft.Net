using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KSoftDotNet.Model.Web;

namespace KSoftDotNet.Interfaces
{
    internal interface IWebManager
    {
        Task<Result> GetData(Uri uri);

        void SetToken(string token);
    }
}

using System.Collections.Generic;
using System.Net;

namespace ExportApiCallToCSV.Model
{
    public interface IRestResponse<out T>
    {
        List<PosReportsResource> Data { get; }
        HttpStatusCode StatusCode { get; set; }
        string ResponseContent { get; set; }
    }
}

using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace ExportApiCallToCSV.Model
{
    public class PosReportsRestResponse : IRestResponse<PosReportsResource>
    {
        public PosReportsRestResponse(HttpStatusCode statusCode, string responseContent)
        {
            Data = statusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<PosReportsResource>>(responseContent) : null;

            StatusCode = statusCode;
            ResponseContent = responseContent;
        }

        public PosReportsRestResponse(HttpStatusCode statusCode, List<PosReportsResource> data)
        {
            Data = data;
            StatusCode = statusCode;
            ResponseContent = string.Empty;
        }

        public List<PosReportsResource> Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ResponseContent { get; set; }
    }
}
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using ExportApiCallToCSV.Model;

namespace ExportApiCallToCSV
{
    class Program
    {
        private const string _posReportsUri = "https://posreportsint.iqmetrix.net";
        private const string _authToken = "MGZqdKE_anQwUGp0MPVadDBnDhtSJBoEBBxePl8iMBd3KSQ3fRZeRQUNHRMFVT0mCFNaEEUcLA1IIxIAeglaDmoWCUdbKAIVAQse";

        static void Main(string[] args)
        {
            var reportingData = GetReportingData().Result;
            const string testFile = @"c:\temp\test.csv";

            using (TextWriter writer = File.CreateText(testFile))
            {
                var csvHelper = new CsvWriter(writer);
                csvHelper.WriteRecords(reportingData.Data);
            }

            Console.WriteLine($"data written to the following location: {testFile}");
            Pause();
        }

        

        private static async Task<IRestResponse<PosReportsResource>> GetReportingData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_posReportsUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", _authToken));

                var response = await client.GetAsync("v1/Companies(15725)/Entities(15725)/ByLocation?DateRange=Date ge datetime'2016-01-01T00:00:00-06:00' and Date le datetime'2016-11-14T23:59:59-06:00'&$top=100");
                if (response.IsSuccessStatusCode)
                {
                    var rawResults = await response.Content.ReadAsStringAsync();
                    return new PosReportsRestResponse(response.StatusCode, rawResults);
                }

                return new PosReportsRestResponse(response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }

        private static void Pause()
        {
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}

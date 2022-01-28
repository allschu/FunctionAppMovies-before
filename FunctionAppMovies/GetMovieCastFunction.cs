using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using FunctionAppMovies.Models;
using Newtonsoft.Json;

namespace FunctionAppMovies
{
    public class GetMovieCastFunction
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public GetMovieCastFunction(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_configuration["MovieDbUrl"]);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { _configuration["MovieDbBearer"] }");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }

        [FunctionName("GetMovieCastFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log, CancellationToken cancellationToken)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string id = req.Query["id"];

            var response = await _httpClient.GetAsync($"3/movie/{id}/credits", cancellationToken).ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            return new OkObjectResult(JsonConvert.DeserializeObject<CastSelection>(content));
        }
    }
}

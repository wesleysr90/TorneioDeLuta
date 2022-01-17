using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TorneioDeLuta.Domain.Entities;
using TorneioDeLuta.Domain.Interface;

namespace TorneioDeLuta.Infrastructure.Service
{
    public class TorneioService : ITorneioService
    {
        private IConfiguration _configuration;
        public TorneioService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Lutador>> GetLutadoresAsync()
        {
            try
            {
                
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri(_configuration["Torneio:UrlTorneio"]);
                request.Method = HttpMethod.Get;       
                request.Headers.Add("x-api-key", _configuration["Torneio:Key"]);
                HttpResponseMessage response = await  httpClient.SendAsync(request);
                
                var responseString = await response.Content.ReadAsStringAsync();
                            
                if (response.StatusCode != System.Net.HttpStatusCode.OK)              
                    throw new Exception(response.RequestMessage.ToString() + " - " + response.StatusCode.ToString());
                

                return JsonConvert.DeserializeObject<List<Lutador>>(responseString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

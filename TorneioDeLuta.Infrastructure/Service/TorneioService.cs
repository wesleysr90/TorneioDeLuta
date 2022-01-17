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

        public async Task<List<Lutador>> GetLutadoresAsync()
        {
            try
            {
                
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://apidev-mbb.t-systems.com.br:8443/edgemicro_tsdev/torneioluta/api/competidores");
                request.Method = HttpMethod.Get;
                request.Headers.Add("x-api-key", "29452a07-5ff9-4ad3-b472-c7243f548a33");
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

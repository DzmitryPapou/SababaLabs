using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FinalTask.ComputerScience.Logic.Interfaces;

namespace FinalTask.ComputerScience.Logic.Facebook
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient _httpClient;

        public RestClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/v3.1/")
            };
        }

        public async Task<string> GetAsync(string uri, CancellationToken cancellationToken)
        {
            try
            {
                using (var response = await _httpClient.GetAsync(uri,cancellationToken))
                {
                    var responseResult = await response.Content.ReadAsStringAsync();

                    return responseResult;
                }
            }
            catch (Exception ex)
            {
                throw new RestClientException("HttpClient Error",ex);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}


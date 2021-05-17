using System;
using System.Net;
using System.Threading.Tasks;

namespace Searchfight.Utility.Functions
{
    public class HttpFunctions : IDisposable
    {
        private bool _disposed = false;

        ~HttpFunctions() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _disposed = true;
        }

        public Task<string> ExecuteDynamicSearchEngineAsync(string urlsearchquery)
        {
            try
            {
                using var client = new WebClient();
                //agent browser desktop
                client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36";
                return client.DownloadStringTaskAsync(urlsearchquery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

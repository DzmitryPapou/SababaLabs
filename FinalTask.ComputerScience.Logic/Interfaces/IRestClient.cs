using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinalTask.ComputerScience.Logic.Interfaces
{
    public interface IRestClient : IDisposable
    {
        Task<string> GetAsync(string uri, CancellationToken cancellationToken);
    }
}
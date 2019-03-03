using System.Threading.Tasks;

namespace FinalTask.ComputerScience.Logic.Interfaces
{
    public interface IAuthenticateService
    {
        Task AuthenticateFacebookAsync();
        void Logout();
    }
}

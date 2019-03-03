using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalTask.ComputerScience.Logic.Models;

namespace FinalTask.ComputerScience.Logic.Interfaces
{
   public interface IFacebookFriends
    {
        Task<IEnumerable<Friends>> GetFriendsAsync(IProgress<double> progress);
    }
}

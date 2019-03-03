using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalTask.ComputerScience.Logic.Models;

namespace FinalTask.ComputerScience.Logic.Interfaces
{
    public interface IFacebookMusic
    {
        Task<Dictionary<string, Music>> GetMusicAsync(IProgress<double> progress);
    }
}
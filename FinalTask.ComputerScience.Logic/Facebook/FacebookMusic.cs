using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FinalTask.ComputerScience.Logic.Interfaces;
using FinalTask.ComputerScience.Logic.Models;
using Newtonsoft.Json.Linq;

namespace FinalTask.ComputerScience.Logic.Facebook
{
    public class FacebookMusic : IFacebookMusic
    {
        private FacebookSession _session;
        private readonly IRestClient _httpClient;

        public FacebookMusic(FacebookSession session, IRestClient httpClient)
        {
            _session = session;
            _httpClient = httpClient;
        }
        private CancellationToken cancellationToken;

        public async Task<Dictionary<string, Music>> GetMusicAsync(IProgress<double> progress)
        {
            var response = await _httpClient.GetAsync("me/friends?fields=id%2Cname%2Cbirthday%2Cpicture%2Clikes&access_token="
                                                      + $"{_session.Token}", cancellationToken);

            JObject myfriends = JObject.Parse(response);
            var users = new List<Friends>();
            var musicList = new Dictionary<string, Music>();
            double pr = 0;
            double prFr = 100 / myfriends["data"].Children().Count();
            foreach (var i in myfriends["data"].Children())
            {
                users.Add(new Friends
                {
                    Name = i["name"].ToString(),
                });
                var likes = i["likes"]["data"];
                double prMus = prFr / likes.Children().Count();
                foreach (var like in likes.Children())
                {
                    if (musicList.ContainsKey(like["name"].ToString()))
                    {
                        musicList[like["name"].ToString()].Rate++;
                    }
                    else
                    {
                        musicList[like["name"].ToString()] = new Music(like["id"].ToString())
                        {
                            Name = like["name"].ToString(),
                            Rate = 1
                        };
                    }
                    progress?.Report(pr += prMus);
                }
            }

            try
            {
                return musicList;
            }
            catch (Exception ex)
            {
               throw new GetMusicException("Data not received!", ex);
            }
        }
    }
}

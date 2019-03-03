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
    public class FacebookFriends : IFacebookFriends
    {
        private IRestClient _httpClient;
        private FacebookSession _session;

        public FacebookFriends(FacebookSession session, IRestClient httpClient)
        {
            _httpClient = httpClient;
            _session = session;
        }

        private CancellationToken cancellationToken;

        public async Task<IEnumerable<Friends>> GetFriendsAsync(IProgress<double> progress)
        {
            var response = await _httpClient.GetAsync("me/friends?fields=id%2Cname%2Cbirthday%2Cpicture%2Clikes&access_token="
                                                      + $"{_session.Token}", cancellationToken);

            JObject myFriends = JObject.Parse(response);
            var users = new List<Friends>();
            double pr = 0;
            double prFr = 100 / myFriends["data"].Children().Count();
            foreach (var i in myFriends["data"].Children())
            {

                users.Add(
                    new Friends
                    {
                        Id = i["id"].ToString(),
                        Name = i["name"].ToString(),
                        Picture = i["picture"]["data"]["url"].ToString(),
                    });
                var names = i["name"];
                double prN = prFr / names.Children().Count();

                progress?.Report(pr + prN);
            }

            try
            {
                return users;
            }
            catch (Exception ex)
            {
                throw new GetFriendsException("Data not received", ex);
            }
        }
    }
}

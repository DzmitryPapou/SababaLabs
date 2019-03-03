using System;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Facebook;
using FinalTask.ComputerScience.Logic;
using FinalTask.ComputerScience.Logic.Facebook;
using FinalTask.ComputerScience.Logic.Interfaces;

namespace FinalTask.ComputerScience.Models
{
    public class FacebookSocialNetwork : IAuthenticateService
    {
        private LocalSettings _settings;
        private FacebookSession _session;
        private const string AppId = "1425964680881295";
        private const string ExtendedPermissions = "user_friends, user_birthday, user_likes";

        public FacebookSocialNetwork(FacebookSession session, LocalSettings settings)
        {
            _session = session;
            _settings = settings;
        }

        public async Task AuthenticateFacebookAsync()
        {
            if (_settings.FacebookToken != null)
            {
                _session.Token = _settings.FacebookToken;
                return;
            }

            var fb = new FacebookClient();
            var redirectUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();

            var loginUri = fb.GetLoginUrl(
                new
                {
                    client_id = AppId,
                    redirect_uri = redirectUri,
                    scope = ExtendedPermissions,
                    display = "popup",
                    response_type = "token"
                });

            var callbackUri = new Uri(redirectUri, UriKind.Absolute);
            try
            {
                var authenticationResult =
                    await
                        WebAuthenticationBroker.AuthenticateAsync(
                            WebAuthenticationOptions.None,
                            loginUri, callbackUri);

                var oAuthResult = fb.ParseOAuthCallbackUrl(new Uri(authenticationResult.ResponseData));
                _session.Token = oAuthResult.AccessToken;
                _settings.FacebookToken = _session.Token;

            }
            catch (Exception ex)
            {
                throw new AuthentificateException("Authentification Error", ex);
            }
        }

        public void Logout()
        {
            _session.Token = null;
            _settings.FacebookToken = null;
        }

    }
}

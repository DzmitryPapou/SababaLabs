using Windows.Storage;

namespace FinalTask.ComputerScience.Models
{
   public class LocalSettings
    {
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        private string _token;
        private const string FacebookAppDataKeys = "AccessToken";

        public string FacebookToken
        {
            get
            {
                if (_token == null)
                {
                    if (_localSettings.Values.TryGetValue($"{FacebookAppDataKeys}", out var obj))
                    {
                        _token = obj as string;
                    }
                }
                return _token;
            }
            set
            {
                _token = value;
                _localSettings.Values[$"{FacebookAppDataKeys}"] = _token;
            }
        }

    }
}

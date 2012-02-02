#region

using System.Configuration;

#endregion

namespace ronin.Configuration
{
    public static class ConfigurationUtility
    {
        public static string GetAppSetting(string settingName, string defaultValue)
        {
            var val = ConfigurationManager.AppSettings[settingName];
            return string.IsNullOrWhiteSpace(val) ? defaultValue : val;
        }
    }
}
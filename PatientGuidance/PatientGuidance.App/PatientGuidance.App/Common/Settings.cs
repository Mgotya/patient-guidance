using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace PatientGuidance.App.Common
{
    public static class Settings
    {
        private static ISettings AppSettings =>
            CrossSettings.Current;

        public static bool IsLogIn
        {
            get => AppSettings.GetValueOrDefault(nameof(IsLogIn), false);
            set => AppSettings.AddOrUpdateValue(nameof(IsLogIn), value);
        }
    }
}

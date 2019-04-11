using System;
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

        public static bool IsSpecial
        {
            get => AppSettings.GetValueOrDefault(nameof(IsSpecial), false);
            set => AppSettings.AddOrUpdateValue(nameof(IsSpecial), value);
        }

        public static bool IsGastro
        {
            get => AppSettings.GetValueOrDefault(nameof(IsGastro), false);
            set => AppSettings.AddOrUpdateValue(nameof(IsGastro), value);
        }

        public static DateTime SelectedDate
        {
            get => AppSettings.GetValueOrDefault(nameof(SelectedDate), DateTime.Today);
            set => AppSettings.AddOrUpdateValue(nameof(SelectedDate), value);
        }

        public static int SelectedHour
        {
            get => AppSettings.GetValueOrDefault(nameof(SelectedHour), DateTime.Now.Hour);
            set => AppSettings.AddOrUpdateValue(nameof(SelectedHour), value);
        }

        public static int SelectedMinutes
        {
            get => AppSettings.GetValueOrDefault(nameof(SelectedMinutes), DateTime.Now.Minute);
            set => AppSettings.AddOrUpdateValue(nameof(SelectedMinutes), value);
        }

        public static string DataMaternityGuidanceCardsgUrl
        {
            get => AppSettings.GetValueOrDefault(nameof(DataMaternityGuidanceCardsgUrl), "https://api.myjson.com/bins/i5om8");
            //set => AppSettings.AddOrUpdateValue(nameof(IsLogIn), value);
        }
    }
}

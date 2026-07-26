using System;
using System.Collections.Generic;
using System.Text;
using System.IO;            // Added for File operations
using System.Text.Json;     // Added for JSON saving

namespace EasyBiz
{
    // 1. YOUR SETTINGS CLASS
    public class SetupSettings
    {
        public string InWords { get; set; } = "";
    }

    // 2. YOUR GLOBAL CONFIG (Now with Save/Load features)
    public static class GlobalConfig
    {
        // Renamed to 'AppSettings' so it doesn't conflict with your Form name!
        public static SetupSettings AppSettings { get; set; } = new SetupSettings();

        // Defines the file name where settings will be saved on the hard drive
        private static readonly string SettingsFilePath = "appsettings.json";

        // Call this exactly once when your application starts (e.g., in MainForm's constructor)
        public static void LoadSettings()
        {
            if (File.Exists(SettingsFilePath))
            {
                string json = File.ReadAllText(SettingsFilePath);
                // Reads the file and loads it into AppSettings
                AppSettings = JsonSerializer.Deserialize<SetupSettings>(json) ?? new SetupSettings();
            }
        }

        // Call this every time you change a setting in your Settings form
        public static void SaveSettings()
        {
            // Converts the AppSettings class into a readable text format and saves it
            string json = JsonSerializer.Serialize(AppSettings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SettingsFilePath, json);
        }
    }
}
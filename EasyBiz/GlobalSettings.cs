using System;
using System.Collections.Generic;
using System.Text;
using System.IO;     
using System.Text.Json;

namespace EasyBiz
{    
    public class SetupSettings
    {
        public string InWords { get; set; } = "";
    }
   
    public static class GlobalConfig
    {
    
        public static SetupSettings AppSettings { get; set; } = new SetupSettings();
    
        private static readonly string SettingsFilePath = "appsettings.json";
    
        public static void LoadSettings()
        {
            if (File.Exists(SettingsFilePath))
            {
                string json = File.ReadAllText(SettingsFilePath);
    
                AppSettings = JsonSerializer.Deserialize<SetupSettings>(json) ?? new SetupSettings();
            }
        }    
        public static void SaveSettings()
        {         
            string json = JsonSerializer.Serialize(AppSettings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SettingsFilePath, json);
        }
        
    }
}
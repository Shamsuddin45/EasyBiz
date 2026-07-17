using Microsoft.Data.Sqlite;

namespace EasyBiz
{
    /// <summary>
    /// Tiny key/value settings store, used to persist the Gemini API key and
    /// model name locally (in the same easybiz.db SQLite file) instead of a
    /// config file. Safe to call InitializeAISettingsTable() repeatedly.
    /// </summary>
    internal static class AISettingsHelper
    {
        public static void InitializeAISettingsTable()
        {
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS AppSettings (
                    SettingKey   TEXT PRIMARY KEY,
                    SettingValue TEXT
                );";
            cmd.ExecuteNonQuery();
        }

        public static string GetSetting(string key, string defaultValue = "")
        {
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT SettingValue FROM AppSettings WHERE SettingKey = @k";
            cmd.Parameters.AddWithValue("@k", key);
            var result = cmd.ExecuteScalar();
            return (result == null || result == System.DBNull.Value) ? defaultValue : result.ToString()!;
        }

        public static void SaveSetting(string key, string value)
        {
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO AppSettings (SettingKey, SettingValue) VALUES (@k, @v)
                ON CONFLICT(SettingKey) DO UPDATE SET SettingValue = excluded.SettingValue;";
            cmd.Parameters.AddWithValue("@k", key);
            cmd.Parameters.AddWithValue("@v", value ?? "");
            cmd.ExecuteNonQuery();
        }
    }
}

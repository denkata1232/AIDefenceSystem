using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SystemMonitor.Core
{
    public static class SettingsManager
    {
        private static readonly string filePath = "settings.json";

        public static AppSettings Load()
        {
            if (!File.Exists(filePath))
                return new AppSettings(); // defaults

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<AppSettings>(json);
        }

        public static void Save(AppSettings settings)
        {
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}

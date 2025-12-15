using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CManager.Infrastructure.Serialization
{
    public class JsonFormatter
    {
        //serialization options

        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
        };

        //convert from C# object to JSON string
        public static string Serialize<T>(T content) => JsonSerializer.Serialize(content, options);

        //convert from JSON string to C# object
        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, options) ?? default;
        }
    }
}

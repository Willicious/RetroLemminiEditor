using System;
using System.Collections.Generic;
using System.IO;

namespace RLEditor
{
    internal sealed class INIFileParser
    {
        private readonly Dictionary<string, string> _values =
            new Dictionary<string, string>();

        private readonly Dictionary<string, List<string>> _indexed =
            new Dictionary<string, List<string>>();

        public static INIFileParser Load(string path)
        {
            var ini = new INIFileParser();

            foreach (var rawLine in File.ReadAllLines(path))
            {
                var line = rawLine.Trim();

                if (line.Length == 0 || line.StartsWith("#"))
                    continue;

                int eq = line.IndexOf('=');
                if (eq < 0)
                    continue;

                string key = line.Substring(0, eq).Trim();
                string value = line.Substring(eq + 1).Trim();

                // Indexed entries: object_0, terrain_12, etc
                int underscore = key.LastIndexOf('_');
                if (underscore > 0)
                {
                    string indexPart = key.Substring(underscore + 1);

                    int dummy;
                    if (int.TryParse(indexPart, out dummy))
                    {
                        string baseKey = key.Substring(0, underscore);

                        List<string> list;
                        if (!ini._indexed.TryGetValue(baseKey, out list))
                        {
                            list = new List<string>();
                            ini._indexed.Add(baseKey, list);
                        }

                        list.Add(value);
                    }
                }
                else
                {
                    ini._values[key] = value;
                }
            }

            return ini;
        }

        public string GetString(string key, string defaultValue = "")
            => _values.TryGetValue(key, out var v) ? v : defaultValue;

        public int GetInt(string key, int defaultValue = 0)
        {
            string val = GetString(key)?.Trim();

            if (string.IsNullOrEmpty(val))
                return defaultValue;

            if (val.Equals("Infinity", StringComparison.OrdinalIgnoreCase))
                return 100;

            return int.TryParse(val, out var v) ? v : defaultValue;
        }

        public bool HasKey(string key) => _values.ContainsKey(key);

        private static readonly IReadOnlyList<string> _emptyList =
            new List<string>();

        public IReadOnlyList<string> GetIndexed(string key)
        {
            List<string> list;
            if (_indexed.TryGetValue(key, out list))
                return list;

            return _emptyList;
        }

        public static int[] ParseIntArray(string ints)
        {
            string[] parts = ints.Split(',');
            int[] values = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
                values[i] = int.Parse(parts[i].Trim());

            return values;
        }

        public static string[] ParseMultiArray(string array)
        {
            var parts = array.Split(',');
            for (int i = 0; i < parts.Length; i++)
                parts[i] = parts[i].Trim();
            return parts;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace RLEditor
{
    public sealed class TriggerMask
    {
        public Rectangle LocalRect { get; }

        private static readonly Dictionary<string, Dictionary<int, Point>> IniOffsetCache = new Dictionary<string, Dictionary<int, Point>>();

        private TriggerMask(Rectangle localRect)
        {
            LocalRect = localRect;
        }

        public bool IsEmpty => LocalRect.IsEmpty;

        public static TriggerMask FromObjectImageKey(string objectImageKey)
        {
            string maskPath = GetMaskPath(objectImageKey);
            if (!File.Exists(maskPath))
                return null;

            using (Bitmap mask = new Bitmap(maskPath))
            {
                Rectangle rect = ExtractTriggerRect(mask);
                if (rect.IsEmpty)
                    return null;

                Point offset = GetTriggerOffset(objectImageKey);
                rect.Offset(offset);

                return new TriggerMask(rect);
            }
        }

        private static string GetMaskPath(string objectImageKey)
        {
            string imagePath = C.AppPathStyles + objectImageKey + ".png";
            return imagePath.Replace("o_", "om_");
        }

        private static Rectangle ExtractTriggerRect(Bitmap mask)
        {
            int minX = mask.Width;
            int minY = mask.Height;
            int maxX = -1;
            int maxY = -1;

            for (int y = 0; y < mask.Height; y++)
            {
                for (int x = 0; x < mask.Width; x++)
                {
                    Color c = mask.GetPixel(x, y);
                    if (IsTriggerPixel(c))
                    {
                        if (x < minX) minX = x;
                        if (y < minY) minY = y;
                        if (x > maxX) maxX = x;
                        if (y > maxY) maxY = y;
                    }
                }
            }

            if (maxX < minX)
                return Rectangle.Empty;

            return Rectangle.FromLTRB(minX, minY, maxX + 1, maxY + 1);
        }

        private static bool IsTriggerPixel(Color c)
        {
            return c.A == 255; // Fully opaque
        }

        private static int GetPieceIndex(string objectImageKey)
        {
            string fileName = Path.GetFileName(objectImageKey);
            int underscoreIndex = fileName.LastIndexOf('_');
            if (underscoreIndex >= 0)
            {
                string numberPart = fileName.Substring(underscoreIndex + 1);
                int.TryParse(numberPart, out int tileIndex);
                return tileIndex;
            }
            return -1;
        }
        public static Point GetTriggerOffset(string objectImageKey)
        {
            int tileIndex = GetPieceIndex(objectImageKey);
            if (tileIndex < 0)
                return Point.Empty;

            string folderPath = Path.Combine(C.AppPathStyles, objectImageKey);
            folderPath = Path.GetDirectoryName(folderPath);

            if (!IniOffsetCache.TryGetValue(folderPath, out var offsetsPerTile))
            {
                offsetsPerTile = new Dictionary<int, Point>();

                string iniPath = Path.Combine(folderPath, Path.GetFileName(folderPath) + ".ini");
                if (File.Exists(iniPath))
                {
                    foreach (string line in File.ReadAllLines(iniPath))
                    {
                        string trimmed = line.Trim();
                        if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#"))
                            continue;

                        int equalIndex = trimmed.IndexOf('=');
                        if (equalIndex < 0)
                            continue;

                        string key = trimmed.Substring(0, equalIndex).Trim();
                        string valueStr = trimmed.Substring(equalIndex + 1).Trim();

                        if (key.StartsWith("maskOffsetX_", StringComparison.OrdinalIgnoreCase) ||
                            key.StartsWith("maskOffsetY_", StringComparison.OrdinalIgnoreCase))
                        {
                            int underscoreIndex = key.LastIndexOf('_');
                            if (underscoreIndex < 0)
                                continue;

                            if (!int.TryParse(key.Substring(underscoreIndex + 1), out int idx))
                                continue;

                            Point existing = offsetsPerTile.ContainsKey(idx) ? offsetsPerTile[idx] : Point.Empty;
                            int val = 0;
                            int.TryParse(valueStr, out val);

                            if (key.StartsWith("maskOffsetX_", StringComparison.OrdinalIgnoreCase))
                                existing.X = val;
                            else
                                existing.Y = val;

                            offsetsPerTile[idx] = existing;
                        }
                    }
                }

                IniOffsetCache[folderPath] = offsetsPerTile;
            }

            if (offsetsPerTile.TryGetValue(tileIndex, out Point offset))
                return offset;

            return Point.Empty;
        }
    }
}
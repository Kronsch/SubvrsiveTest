using System.Collections.Generic;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Base.Logging
{
    public static class LoggableColors
    {
        private static string _defaultColor = "cyan";
        private static Dictionary<string, string> _loggableColors = new();

        public static string GetRandomColor(string typeName)
        {
            if(_loggableColors.ContainsKey(typeName))
                return _loggableColors[typeName];

            Color randomColor = Random.ColorHSV();
            string hexCode = $"#{ColorUtility.ToHtmlStringRGBA(randomColor)}";
            _loggableColors.Add(typeName, hexCode);
            return hexCode;
        }

        public static string GetDefaultColor() => _defaultColor;
    }
}

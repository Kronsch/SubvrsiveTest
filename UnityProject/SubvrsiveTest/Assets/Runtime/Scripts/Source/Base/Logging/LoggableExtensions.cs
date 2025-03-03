using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Base.Logging
{
    public static class LoggableExtensions
    {
        private static string GetLoggableType(ILoggable loggable) => loggable.GetType().Name;
        private static string CreateLogMessage(ILoggable loggable, string message)
        {
            var typeString = GetLoggableType(loggable);
            var colorString = LoggableColors.GetRandomColor(typeString);
            var loggableTypeString = $"[<color={colorString}>{typeString}</color>]";
            return $"{loggableTypeString}: {message}";
        }

        public static void Log(this ILoggable loggable, string message)
        {
            if(loggable.DebugLogsEnabled)
            {
                Debug.Log(CreateLogMessage(loggable, message));
            }
        }

        public static void LogError(this ILoggable loggable, string message)
        {
            if(loggable.DebugLogsEnabled)
            {
                Debug.LogError(CreateLogMessage(loggable, message));
            }
        }

        public static void LogWarning(this ILoggable loggable, string message)
        {
            if(loggable.DebugLogsEnabled)
            {
                Debug.LogWarning(CreateLogMessage(loggable, message));
            }
        }
    }
}

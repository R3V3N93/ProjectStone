using UnityEngine;

public struct Log
{
    public enum SeverityT
    {
        Debug,
        Warning,
        Error,
    };

    public static void Message(string name, string message, SeverityT severity)
    {
        switch (severity)
        {
            case SeverityT.Debug:
                UnityEngine.Debug.Log("<color=green>" + name + "</color> : " + message);
                break;
            case SeverityT.Warning:
                UnityEngine.Debug.Log("<color=orange>" + name + "</color> : " + message);
                break;
            case SeverityT.Error:
                UnityEngine.Debug.Log("<color=red>" + name + "</color> : " + message);
                break;
        }
    }

    public static void Debug(string name, string message) {Message(name, message,  SeverityT.Debug); }
    public static void Warning(string name, string message) {Message(name, message,  SeverityT.Debug); }
    public static void Error(string name, string message) {Message(name, message,  SeverityT.Debug); }
}

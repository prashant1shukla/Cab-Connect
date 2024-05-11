using System;
using System.IO;

public class Logger : IDisposable
{
    private static Logger? instance; 
    private readonly string logFilePath;
    private StreamWriter? logWriter;

    private Logger(string logFilePath)
    {
        this.logFilePath = logFilePath;
        logWriter = new StreamWriter(logFilePath, true);
    }

    public static Logger Instance
    {
        get
        {
            instance ??= new Logger("log.txt");
            return instance;
        }
    }

    private void Log(string message)
    {
        logWriter?.WriteLine($"{DateTime.Now}: {message}");
        logWriter?.Flush();
    }

    public void Dispose()
    {
        logWriter?.Dispose();
    }

    public static void Main(string[] args)
    {
        using var logger = Logger.Instance;
        logger.Log("Logging a message to the log file.");
    }
}

// Filename: ILogger.cs
// Author: Vasil K.
// Date: 18:33:31  11/21/2018
namespace Logger.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string errorMessage);
        void Info(string dateTime, string info);
    }
}

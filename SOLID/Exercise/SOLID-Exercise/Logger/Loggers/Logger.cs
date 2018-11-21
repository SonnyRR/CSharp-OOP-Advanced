// Filename: Logger.cs
// Author: Vasil K.
// Date: 18:46:12  11/21/2018
namespace Logger.Loggers
{
    using Contracts;
    using Appenders;

    public class Logger : ILogger
    {
        private readonly IAppender appender;

        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.appender.Append(dateTime, "Error", errorMessage);
        }

        public void Info(string dateTime, string info)
        {
            this.appender.Append(dateTime, "Info", info);
        }
    }
}

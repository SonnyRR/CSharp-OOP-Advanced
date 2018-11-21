// Filename: ConsoleAppender.cs
// Author: Vasil K.
// Date: 18:39:28  11/21/2018
namespace Logger.Appenders
{
    using System;
    using Contracts;
    using Layouts.Contracts;

    public class ConsoleAppender : IAppender
    {
        private readonly ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public void Append(string dateTime, string errorLevel, string message)
        {
            Console.WriteLine(string.Format(layout.Format, dateTime, errorLevel, message));

        }
    }
}

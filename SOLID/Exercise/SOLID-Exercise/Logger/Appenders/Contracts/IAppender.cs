// Filename: IAppender.cs
// Author: Vasil K.
// Date: 18:34:07  11/21/2018
namespace Logger.Contracts
{
    public interface IAppender
    {
        void Append(string dateTime, string errorLevel, string message);
    }
}

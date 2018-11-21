// Filename: SimpleLayout.cs
// Author: Vasil K.
// Date: 18:35:56  11/21/2018
namespace Logger.Layouts
{
    using Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format
        {
            get { return "{0} - {1} - {2}"; }
        }
    }
}

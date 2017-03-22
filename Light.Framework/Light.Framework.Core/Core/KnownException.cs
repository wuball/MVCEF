using System;

namespace Light.Framework.Core.Core
{
    public class KnownException : Exception
    {
        public KnownException(string message) : base(string.IsNullOrEmpty(message) ? "Unknown Exception" : message)
        {

        }
    }
}

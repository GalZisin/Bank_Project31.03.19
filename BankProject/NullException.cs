using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    internal class NullException : Exception
    {
        public NullException()
        {
        }

        public NullException(string message) : base(message)
        {
        }

        public NullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
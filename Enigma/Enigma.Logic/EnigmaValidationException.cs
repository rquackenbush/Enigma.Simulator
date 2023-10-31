using System.Runtime.Serialization;

namespace Enigma.Logic
{
    public class EnigmaValidationException : Exception
    {
        public EnigmaValidationException()
        {
        }

        public EnigmaValidationException(string? message) : base(message)
        {
        }

        public EnigmaValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EnigmaValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
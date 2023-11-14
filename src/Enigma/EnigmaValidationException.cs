using System.Runtime.Serialization;

namespace Enigma
{
    /// <summary>
    /// Thrown when an Enigma machine configuration can't be validated.
    /// </summary>
    public class EnigmaValidationException : Exception
    {
        /// <summary>
        /// Creates an instance of the <see cref="EnigmaValidationException"/> class.
        /// </summary>
        public EnigmaValidationException()
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="EnigmaValidationException"/> class.
        /// </summary>
        public EnigmaValidationException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="EnigmaValidationException"/> class.
        /// </summary>
        public EnigmaValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="EnigmaValidationException"/> class.
        /// </summary>
        protected EnigmaValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
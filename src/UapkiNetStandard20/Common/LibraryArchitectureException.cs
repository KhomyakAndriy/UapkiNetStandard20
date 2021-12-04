using System;
using System.Runtime.Serialization;

// Note: Code in this file is maintained manually.

namespace UapkiNetStandard20.Common
{
    /// <summary>
    /// Exception indicating an attempt to load unmanaged PKCS#11 library designated for a different architecture
    /// </summary>
    [Serializable]
    public class LibraryArchitectureException : Exception
    {
        /// <summary>
        /// Initializes new instance of LibraryArchitectureException class
        /// </summary>
        public LibraryArchitectureException()
            : this(Platform.Uses64BitRuntime ? "Unable to load 32-bit unmanaged library into 64-bit runtime" : "Unable to load 64-bit unmanaged library into 32-bit runtime")
        {

        }

        /// <summary>
        /// Initializes a new instance of LibraryArchitectureException class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public LibraryArchitectureException(Exception innerException)
            : this(Platform.Uses64BitRuntime ? "Unable to load 32-bit unmanaged library into 64-bit runtime" : "Unable to load 64-bit unmanaged library into 32-bit runtime", innerException)
        {

        }

        /// <summary>
        /// Initializes new instance of LibraryArchitectureException class
        /// </summary>
        /// <param name="message">Message that describes the error</param>
        public LibraryArchitectureException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of LibraryArchitectureException class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public LibraryArchitectureException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes new instance of LibraryArchitectureException class with serialized data
        /// </summary>
        /// <param name="info">SerializationInfo that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">StreamingContext that contains contextual information about the source or destination</param>
        protected LibraryArchitectureException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}

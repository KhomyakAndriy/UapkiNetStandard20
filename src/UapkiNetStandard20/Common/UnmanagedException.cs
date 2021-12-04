using System;
using System.Runtime.Serialization;

namespace UapkiNetStandard20.Common
{
    /// <summary>
    /// Exception indicating that unmanaged function has returned error
    /// </summary>
    [Serializable]
    public class UnmanagedException : Exception
    {
        /// <summary>
        /// Error code returned by the last unmanaged function.
        /// Errors are explained at https://docs.microsoft.com/en-us/windows/desktop/Debug/system-error-codes
        /// </summary>
        private int? _errorCode = null;

        /// <summary>
        /// Error code returned by the last unmanaged function.
        /// Errors are explained at https://docs.microsoft.com/en-us/windows/desktop/Debug/system-error-codes
        /// </summary>
        public int? ErrorCode
        {
            get
            {
                return _errorCode;
            }
        }

        /// <summary>
        /// Initializes new instance of UnmanagedException class
        /// </summary>
        /// <param name="message">Message that describes the error</param>
        public UnmanagedException(string message)
            : base(message)
        {
            _errorCode = null;
        }

        /// <summary>
        /// Initializes new instance of UnmanagedException class
        /// </summary>
        /// <param name="message">Message that describes the error</param>
        /// <param name="errorCode">Error code returned by the last unmanaged function</param>
        public UnmanagedException(string message, int errorCode)
            : base(message)
        {
            _errorCode = errorCode;
        }

        /// <summary>
        /// Initializes new instance of UnmanagedException class with serialized data
        /// </summary>
        /// <param name="info">SerializationInfo that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">StreamingContext that contains contextual information about the source or destination</param>
        protected UnmanagedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            bool errorCodeSet = info.GetBoolean("ErrorCodeSet");

            if (errorCodeSet)
                _errorCode = info.GetInt32("ErrorCode");
        }

        /// <summary>
        /// Populates a SerializationInfo with the data needed to serialize the target object
        /// </summary>
        /// <param name="info">SerializationInfo to populate with data</param>
        /// <param name="context">The destination for this serialization</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            bool errorCodeSet = (_errorCode != null);
            info.AddValue("ErrorCodeSet", errorCodeSet);

            if (errorCodeSet)
                info.AddValue("ErrorCode", _errorCode.Value);

            base.GetObjectData(info, context);
        }
    }
}

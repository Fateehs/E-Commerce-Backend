using System.Runtime.Serialization;

namespace ETradeAPI.Application.Exceptions
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException() : base("An unexpected error was encountered while creating a user.")
        {
        }

        public UserCreateFailedException(string? message) : base(message)
        {
        }

        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserCreateFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

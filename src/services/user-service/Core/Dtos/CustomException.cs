using System;
namespace user_service.Core.Dtos
{
    public class CustomException
    {
        public CustomException()
        {
        }
    }

    [Serializable]
    public class NoDataException : Exception
    {
        public string ErrorMessage { get; set; }

        public NoDataException() {
            ErrorMessage = "No data returned";
        }

        public NoDataException(string message)
            : base(message) {
            ErrorMessage = message;
        }

        public NoDataException(string message, Exception inner)
            : base(message, inner)
        {
            ErrorMessage = message;

        }
    }
    }

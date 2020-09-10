using System;
namespace user_service.Core.Dtos
{
    public class Utils
    {
        public bool is_disounted { get; set; }
    }

    public class ErrorObject
    {
        public string Message { get; set; }

        public object Data { get; set; }

        public object Status { get; set; }

        public ErrorObject(string message)
        {
            Message = message;
            Data = null;
            Status = "error";
        }
    }
}

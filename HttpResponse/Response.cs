using System;

namespace HttpResponse
{
    public class Response<T>
    {
        public Response(ResponseStatus status , T data)
        {
            Status = status;
            Data = data;
        }

        public ResponseStatus Status { get; set; }
        public T Data { get; set; }

     
    }
    public enum ResponseStatus
    {
        Success,
        Error,
    }

}

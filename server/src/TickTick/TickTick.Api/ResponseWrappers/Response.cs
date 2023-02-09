using System.Net;

namespace TickTick.Api.ResponseWrappers
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string[] Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }


        public Response() { }
        public Response(T data) : this(data, HttpStatusCode.OK, string.Empty, null) { }
        public Response(T data, HttpStatusCode statusCode) : this(data, statusCode, string.Empty, null) { }
        public Response(T data, HttpStatusCode statusCode, string message) :this(data, statusCode, message, null)  { }
        public Response(T data, HttpStatusCode statusCode, string message, string[] errors)
        {
            this.Data = data;
            this.StatusCode = statusCode;
            this.Message = message;
            this.Errors = errors;
        }
    }
}


/*

 
 
 
*/

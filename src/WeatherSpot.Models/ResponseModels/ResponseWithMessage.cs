namespace WeatherSpot.Models.ResponseModels
{
    using System.Net;

    public class ResponseWithMessage
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }

        public ResponseWithMessage(HttpStatusCode status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}

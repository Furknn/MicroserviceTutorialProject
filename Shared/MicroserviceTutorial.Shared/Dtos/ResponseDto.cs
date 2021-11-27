using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MicroserviceTutorial.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; private set; }
        [JsonIgnore] public int StatusCode { get; private set; }
        [JsonIgnore] public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; private set; }

        //Static factory methods
        public static ResponseDto<T> Success(T data, int stausCode)
        {
            return new ResponseDto<T>()
            {
                Data = data,
                StatusCode = stausCode,
                IsSuccessful = true
            };
        }

        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T>()
            {
                IsSuccessful = true,
                StatusCode = statusCode
            };
        }

        public static ResponseDto<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseDto<T>()
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static ResponseDto<T> Fail(string error, int statusCode)
        {
            return new ResponseDto<T>()
            {
                Errors = new List<string>()
                {
                    error
                },
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
    }
}
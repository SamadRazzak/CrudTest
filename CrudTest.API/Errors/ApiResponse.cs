﻿namespace CrudTest.API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request.",
                401 => "Not authorised.",
                404 => "Resource not found.",
                403 => "Forbidden",
                500 => "Internal server error.",
                _ => null
            };
        }
    }
}

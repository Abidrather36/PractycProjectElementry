using Convocation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Application.ApiResponse
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }

        public T? Result { get; set; }


        public string Message { get; set; } = "";


        public StatusCode statusCode { get; set; }


        public static ApiResponse<T> SuccessResponse(T? result ,string message="",StatusCode  statusCode =StatusCode.OK)
        {
            return new ApiResponse<T>
            {
                Result = result,
                Message = message,
                statusCode = statusCode,
                IsSuccess=true
            };

        }

        public static ApiResponse<T> ErrorResponse(string message="",StatusCode statusCode=StatusCode.BadRequest)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Message = message,
                statusCode = statusCode,
            };

        }
    }
}

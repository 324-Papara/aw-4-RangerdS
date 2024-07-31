using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Base.Response
{
    public partial class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public Guid TransactionId { get; set; } = Guid.NewGuid();

        public ApiResponse()
        {
            IsSuccess = true;
        }

        public ApiResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    public partial class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }

        public ApiResponse(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public ApiResponse(T data, bool isSuccess, string message)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketAPI.Commons
{
    public class ResponseService<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }

        public ResponseService(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        public ResponseService(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
    }
}

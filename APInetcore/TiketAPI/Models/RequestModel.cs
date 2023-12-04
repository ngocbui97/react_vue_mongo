using System;

namespace TiketAPI.Models
{
    public class RequestModel<T>
    {
        public T data { get; set; }
        public Exception ex { get; set; }
    }
}

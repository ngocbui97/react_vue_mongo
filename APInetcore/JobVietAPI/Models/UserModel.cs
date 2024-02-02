using System;
using System.Text.Json.Serialization;
using JobVietAPI.Params;

namespace JobVietAPI.Models
{
    public class UserModel : UserParam
    {
        public Guid id { get; set; }
    }
    public class ResponseLoginModel : UserModel
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }
}

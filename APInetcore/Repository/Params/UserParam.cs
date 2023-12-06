using Repository.CustomModels;

namespace Repository.Params
{
    public class LoginParam
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class EmailParam
    {
        public string email { get; set; }
    }
    public class ResetPassParam
    {
        public string email { get; set; }
        public string code { get; set; }
        public string password { get; set; }
    }
    public class SearchUserParam : PagingParam
    {
        public string name { get; set; }
        public string email { get; set; }
        public int ? age_from { get; set; }
        public int  ? age_to { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string phone { get; set; }
        public string current_position { get; set; }
        public string user_type { get; set; }
    }
}

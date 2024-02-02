namespace JobVietAPI
{
    public class Constants
    {
        public static readonly string CONF_CROSS_ORIGIN = "AllowedHosts";
        public static readonly int DEFAULT_STATUS_PROFILE = 0;

        public static readonly int ROLE_ADDMIN = 0;
        public static readonly int ROLE_HR = 1;
        public static readonly int ROLE_MEMBER = 2;

        public static readonly string SESSION_LOGIN = "session_login";
        public static readonly string KEY_SESSION_EMAIL = "email";

        public static readonly string CONF_HOST_CRM = "https://";
        public enum AUTHOR { TOKEN, SECRET_KEY, TOKEN_OR_KEY };
        public const string SUBJECT_REGISTER = "Register account success from Job Viet";
        public const string CONTENT_REGISTER = "Welcome to our service!";
        public const string SUBJECT_FORGOT_PASSWORD = "Forgot password from Job Viet";
        public const string CONTENT_FORGOT_PASSWORD = "Click this link to reset password: ";
        public const string SALT_KEY = "Kaepf5wqbb259704";// 16 character
    }
}

namespace Shared.Web.Mvc.Infrastructure.Validation
{
    public static class Constants
    {
        public const string EMAIL_REGEX =
            @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        public const string EMAIL_MSG = "Must be a valid email.";
    }
}
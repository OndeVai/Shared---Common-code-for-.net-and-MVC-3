namespace Shared.Infrastructure.Security.Dto
{
    public class MembershipUserCreateRequest : BaseUserRequest
    {
        public MembershipUserCreateRequest(string userName, string password, string email, string passwordQuestion,
                                           string passwordAnswer, bool isApproved)
            : base(userName, password)
        {
            Email = email;
            PasswordQuestion = passwordQuestion;
            PasswordAnswer = passwordAnswer;
            IsApproved = isApproved;
        }

        public string Email { get; private set; }

        public string PasswordQuestion { get; private set; }

        public string PasswordAnswer { get; private set; }

        public bool IsApproved { get; private set; }
    }
}
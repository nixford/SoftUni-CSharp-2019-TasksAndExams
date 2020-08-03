namespace P02._Identity_After
{
    using Contracts;

    public class AccountController : IPasswordChanger
    {
        private readonly IPasswordChanger manager;

        public AccountController(IPasswordChanger manager)
        {
            this.manager = manager;
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            this.manager.ChangePassword(oldPass, newPass);
        }
    }
}

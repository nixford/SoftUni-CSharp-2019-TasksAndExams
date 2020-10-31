namespace MUSACA.ViewModels.BindingModels.Users
{
    public class UserLoginInputModel
    {
        private const string ErrorMessage = "Invalid username or password!";
            
        public string Username { get; set; }
             
        public string Password { get; set; }
    }
}

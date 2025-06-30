namespace FamilyStoryApi.Application.Results
{
    public class LoginResult
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public LoginResult(string name, string email, string token) 
        { 
            Name = name;
            Email = email;
            Token = token;
        }
    }
}

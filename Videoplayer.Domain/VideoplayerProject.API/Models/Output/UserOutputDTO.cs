namespace VideoplayerProject.API.Models.Output
{
    public class UserOutputDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserOutputDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}

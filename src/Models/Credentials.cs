namespace Keylume.Models
{
    public class Credentials(string identifier, string username, string password, string notes = "")
    {
        public string Identifier { get; } = identifier;
        public string Username { get; } = username;
        public string Password { get; } = password;
        public string Notes { get; } = notes;
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
    }
}

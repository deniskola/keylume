using Keylume.Models;

namespace Keylume.Services
{
    public class PasswordManager
    {
        private readonly string filePath;
        private readonly EncryptionService encryptionService;
        private List<Credentials> credentials;

        public PasswordManager(string filePath, EncryptionService encryptionService, List<Credentials> credentials)
        {
            this.filePath = filePath;
            this.encryptionService = encryptionService;
            this.credentials = credentials;
        }

        public void StorePassword(string identifier, string username, string password, string notes = "")
        {
            credentials.Add(new Credentials(identifier, username, encryptionService.Decrypt(password), notes));
        }

        public string RetrievePassword(string identifier)
        {
            var credential = credentials.FirstOrDefault(x => x.Identifier == identifier);
            return credential != null ? encryptionService.Decrypt(credential.Password) : "Not found";
        }
    }
}

using Keylume.Models;
using System.Net;
using System.Text.Json;

namespace Keylume.Services
{
    public class PasswordManager
    {
        private readonly string filePath;
        private readonly EncryptionService encryptionService;
        private List<Credentials> credentials;

        public PasswordManager(EncryptionService encryptionService, string filePath)
        {
            this.filePath = filePath;
            this.encryptionService = encryptionService;
            this.credentials = LoadCredentials();
        }

        private List<Credentials> LoadCredentials()
        {
            if (!File.Exists(filePath)) return new List<Credentials>();

            try
            {
                string encryptedJson = File.ReadAllText(filePath);
                string decryptedJson = encryptionService.Decrypt(encryptedJson);
                return JsonSerializer.Deserialize<List<Credentials>>(decryptedJson) ?? new List<Credentials>();
            }
            catch
            {
                return new List<Credentials>();
            }
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

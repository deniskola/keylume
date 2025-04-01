namespace Keylume.Utils
{
    public static class PasswordGenerator
    {
        private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string Numbers = "0123456789";
        private const string Symbols = "!@#$%^&*()-_=+<>?";

        public static string Generate(int length = 16, bool includeSymbols = true)
        {
            string validChars = Uppercase + Lowercase + Numbers;
            if (includeSymbols) validChars += Symbols;

            Random random = new Random();
            return new string(Enumerable.Repeat(validChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
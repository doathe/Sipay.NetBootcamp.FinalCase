using System.Security.Cryptography;

namespace BillingSystem.Application;

public static class RandomPasswordGenerator
{
    private const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
    private const string UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string DIGITS = "0123456789";
    private const string SPECIAL_CHARACTERS = "!@#$%^&*()-_=+[]{}|;:,.<>?";

    public static string GenerateRandomPassword()
    {
        Random random = new Random();
        int passwordLength = random.Next(6, 11); // Uzunluk 6 ile 10 arasında rastgele bir değer
        return GeneratePassword(passwordLength);
    }

    public static string GeneratePassword(int length)
    {
        string allCharacters = LOWERCASE + UPPERCASE + DIGITS + SPECIAL_CHARACTERS;
        using (var random = new RNGCryptoServiceProvider())
        {
            var password = new char[length];
            for (int i = 0; i < length; i++)
            {
                byte[] buffer = new byte[sizeof(char)];
                random.GetBytes(buffer);

                int randomIndex = BitConverter.ToUInt16(buffer, 0) % allCharacters.Length;
                password[i] = allCharacters[randomIndex];
            }

            return new string(password);
        }
    }
}
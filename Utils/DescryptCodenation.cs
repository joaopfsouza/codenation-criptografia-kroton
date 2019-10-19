using System;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public static class DescryptCodenation
    {
        public static string JulioCesarDescryptionTool(string textToManipulation, int encryptionInterval, char type = 'd')
        {

            StringBuilder textEncrypt = new StringBuilder();

            char[] characterToEncryptArray = textToManipulation.ToLower().ToCharArray();

            foreach (var character in characterToEncryptArray)
            {
                if (type == 'e')
                    textEncrypt.Append(EncryptionRule(character, encryptionInterval));
                else
                    textEncrypt.Append(DescryptionRule(character, encryptionInterval));

            }

            return textEncrypt.ToString();
        }

        static char EncryptionRule(char characterToEncrypt, int encryptionInterval)
        {
            int encryptedCharacter = 0;
            int asciiCharacterNumber = Convert.ToInt32(characterToEncrypt);
            int normalizedEncryptionInterval = encryptionInterval % 26;
            System.Console.WriteLine($"Resto: {normalizedEncryptionInterval}");

            if (asciiCharacterNumber >= 97 && asciiCharacterNumber <= 122)
            {
                encryptedCharacter = (asciiCharacterNumber + normalizedEncryptionInterval) > 122 ? (asciiCharacterNumber - 26 + normalizedEncryptionInterval) : (asciiCharacterNumber + normalizedEncryptionInterval);
                return Convert.ToChar(encryptedCharacter);
            }
            else
            {
                return characterToEncrypt;
            }


        }

        static char DescryptionRule(char characterToDescrypt, int descryptionInterval)
        {
            int descryptedCharacter = 0;
            int asciiCharacterNumber = Convert.ToInt32(characterToDescrypt);
            int normalizedEncryptionInterval = descryptionInterval % 26;

            if (asciiCharacterNumber >= 97 && asciiCharacterNumber <= 122)
            {
                descryptedCharacter = (asciiCharacterNumber - normalizedEncryptionInterval) < 97 ? (asciiCharacterNumber + 26 - normalizedEncryptionInterval) : (asciiCharacterNumber - normalizedEncryptionInterval);
                return Convert.ToChar(descryptedCharacter);
            }
            else
            {
                return characterToDescrypt;
            }
        }
        public static string ConvertSHA1(string textToSha1)
        {
             byte[] byteData = Encoding.ASCII.GetBytes(textToSha1);
            SHA1 sha = new SHA1CryptoServiceProvider();
            var result = sha.ComputeHash(byteData);

            string hashString = string.Empty;
            foreach (var item in result)
            {
                hashString += string.Format("{0:x2}", item);
            }

            return hashString;
        }
    }


}